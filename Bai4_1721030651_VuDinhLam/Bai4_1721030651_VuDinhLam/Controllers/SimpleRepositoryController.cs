using AutoMapper;
using Bai4_1721030651_VuDinhLam.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bai4_1721030651_VuDinhLam.Repository;
using Bai4_1721030651_VuDinhLam.Models;

namespace Bai4_1721030651_VuDinhLam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleRepositoryController : ControllerBase
    {
        private readonly IProductRepository _product;
        public SimpleRepositoryController(IProductRepository product)
        {
            _product = product;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _product.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _product.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            var product = await _product.Create(productDto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO productDto)
        {
            if (id != productDto.Id) return BadRequest();
            await   _product.Update(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await   _product.Delete(id);
            return NoContent();
        }
    }
}
