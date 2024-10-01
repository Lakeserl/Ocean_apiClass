using Bai4_1721030651_VuDinhLam.Models;
using Bai4_1721030651_VuDinhLam.Repository.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai4_1721030651_VuDinhLam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericReposittoryController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public GenericReposittoryController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetListAsync();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newProduct = await _repository.CreateAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest("Product ID mismatch");

            await _repository.UpdateAsync(product);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product == null)
                return NotFound();

            await _repository.DeleteAsync(product);
            return NoContent();
        }


    }
}
