using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore_Linq.Models;

namespace EntityFrameworkCore_Linq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityFrameworkCore_Linq : ControllerBase
    {
        private readonly EfcoreLinqDemoContext _context;

        public EntityFrameworkCore_Linq(EfcoreLinqDemoContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        // Get: api/Products/names
        [HttpGet("names")]
        public async Task<ActionResult<IEnumerable<string>>> GetProductNames()
        {
            return await _context.Products.Select(p => p.ProductName).ToListAsync();
        }
        // Get api/Products/non-discontinued
        [HttpGet("non-discontinued")]
        public async Task<ActionResult<IEnumerable<Product>>> GetNonDiscontinuedProducts()
        {
            return await _context.Products
                                 .Where(p => p.Discontinued == false)
                                 .ToListAsync();
        }
        // Get api/Products/price_>_20
        [HttpGet("price_>_20")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsPriceGreaterThan20()
        {
            return await _context.Products
                                 .Where(p => p.UnitPrice > 20)
                                 .ToListAsync();
        }
        // Get api/Products/sorted-by-name
        [HttpGet("sorted-by-name")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsSortedByName()
        {
            return await _context.Products
                                 .OrderBy(p => p.ProductName)
                                 .ToListAsync();
        }
        // Get api/Product/count_product
        [HttpGet("count_product")]
        public async Task<ActionResult<int>> GetCountProduct()
        {
            return await _context.Products.CountAsync();
        }
        //Get api/Product/names_&_suppliers
        [HttpGet("names_&_suppliers")]
        public async Task<ActionResult<IEnumerable<Product>>> GetNameAndSuppiers(int supplierId)
        {
            return await _context.Products
                     .Where(p => p.SupplierId == supplierId)
                     .ToListAsync();
        }
        // Get api/Product/categoryId
        [HttpGet("Category/catgoryId")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int CategoryId)
        {
            return await _context.Products
                                 .Where(p => p.CategoryId == CategoryId)
                                 .ToListAsync();
        }
        // Get api/Product/SupplierId
        [HttpGet("Supplier/SupplierId")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductBySuppliers(int SupplierId)
        {
            return await _context.Products
                                  .Where(p => p.SupplierId == SupplierId)
                                  .ToListAsync();
        }

        //Get api/Supplier/suppliers-with-products
        [HttpGet("suppliers-with-products")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliersWithProducts()
        {
            return await _context.Suppliers
                                 .Where(p => p.Products.Any())
                                 .ToListAsync();
        }
        // GET api/Product/most-expensive
        [HttpGet("most-expensive")]
        public async Task<ActionResult<Product>> GetMostExpensiveProduct()
        {
            return await _context.Products
                                 .OrderByDescending(p => p.UnitPrice)
                                 .FirstOrDefaultAsync();
        }

        //Get api/Product/cheapest
        [HttpGet("cheapest")]
        public async Task<ActionResult<Product>> GetCheapestProduct()
        {
            return await _context.Products
                                 .OrderBy(p => p.UnitPrice)
                                 .FirstOrDefaultAsync();
        }
        // Get api/Product/call_category_name
        // 13. Lấy danh sách các sản phẩm với tên danh mục tương ứng
        [HttpGet("getProductsWithCategory")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategory()
        {
            return await _context.Products
                                 .Select(p => new
                                 {
                                     p.ProductName,
                                     p.Category.CategoryName
                                 })
                                 .ToListAsync();
        }
        // Get api/Product/call_supplier_name
        // 14. Lấy danh sách sản phẩm và nhà cung cấp tương ứng
        [HttpGet("getProductsWithSupplier")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithSupplier()
        {
            return await _context.Products
                                 .Select(p => new
                                 {
                                     p.ProductName,
                                     p.Supplier.CompanyName
                                 })
                                 .ToListAsync();
        }
        // Get api/Product/price_equals_average
        // 15. Lấy danh sách sản phẩm có giá bằng giá trị trung bình
        [HttpGet("price_equals_average")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithPriceEqualsAverage()
        {
            var average = await _context.Products.AverageAsync(p => p.UnitPrice);
            return await _context.Products
                                 .Where(p => p.UnitPrice == average)
                                 .ToListAsync();
        }
        // Get api/Product/sum_product
        // 16. Tính tổng số sản phẩm trong mỗi danh mục
        [HttpGet("category-product-count")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductCountPerCategory()
        {
            return await _context.Products
                                 .GroupBy(p => p.Category.CategoryName)
                                 .Select(g => new { Category = g.Key, ProductCount = g.Count() })
                                 .ToListAsync();
        }
        // Get api/ Product/categories-with-product-count
        // 17. Lấy danh sách các danh mục và tổng số lượng sản phẩm trong mỗi danh mục
        [HttpGet("categories-with-product-count")]
        public async Task<ActionResult<IEnumerable<object>>> GetCategoriesWithProductCount()
        {
            return await _context.Categories
                                 .Select(c => new
                                 {
                                     c.CategoryName,
                                     ProductCount = c.Products.Count
                                 })
                                 .ToListAsync();
        }

        // Get api/suppliers-without-products
        // 18. Lấy danh sách các nhà cung cấp không có sản phẩm
        [HttpGet("suppliers-without-products")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliersWithoutProducts()
        {
            return await _context.Suppliers
                                 .Where(s => !s.Products.Any())
                                 .ToListAsync();
        }

        //Get api/ price-greater-than-average
        // 19.Lấy danh sách các sản phẩm có giá lớn hơn giá trung bình của tất cả các sản phẩm:
        [HttpGet("price-greater-than-average")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithPriceGreaterThanAverage()
        {
            var average = await _context.Products.AverageAsync(p => p.UnitPrice);
            return await _context.Products
                                 .Where(p => p.UnitPrice > average)
                                 .ToListAsync();
        }

        //Get api/ with-category-and-supplier-names
        // 20. Lấy danh sách tên sản phẩm cùng với danh mục và nhà cung cấp
        [HttpGet("with-category-and-supplier-names")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategoryAndSupplierNames()
        {
            return await _context.Products
                                 .Select(p => new
                                 {
                                     p.ProductName,
                                     p.Category.CategoryName,
                                     p.Supplier.CompanyName
                                 })
                                 .ToListAsync();
        }
        // Get api / discontinued-and-price-greater-than-50
        [HttpGet("discontinued-and-price-greater-than-50")]
        public async Task<ActionResult<IEnumerable<Product>>> GetDiscontinuedAndPriceGreaterThan50()
        {
            return await _context.Products
                                 .Where(p => p.Discontinued && p.UnitPrice > 50)
                                 .ToListAsync();
        }
        // Get api / category-with-most-products
        [HttpGet("category-with-most-products")]
        public async Task<ActionResult<object>> GetCategoryWithMostProducts()
        {
            return await _context.Products
                                 .GroupBy(p => p.Category.CategoryName)
                                 .OrderByDescending(g => g.Count())
                                 .Select(g => new { Category = g.Key, ProductCount = g.Count() })
                                 .FirstOrDefaultAsync();
        }
        // Get api / supplier-with-most-products
        // 23. Tìm nhà cung cấp có nhiều sản phẩm nhất
        [HttpGet("supplier-with-most-products")]
        public async Task<ActionResult<object>> GetSupplierWithMostProducts()
        {
            return await _context.Products
                                 .GroupBy(p => p.Supplier.CompanyName)
                                 .OrderByDescending(g => g.Count())
                                 .Select(g => new { Supplier = g.Key, ProductCount = g.Count() })
                                 .FirstOrDefaultAsync();
        }
        // Get api / supplier-product-count
        // 24. Lấy danh sách sản phẩm với số lượng sản phẩm của từng nhà cung cấp
        [HttpGet("supplier-product-count")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithSupplierProductCount()
        {
            return await _context.Products
                                 .GroupBy(p => p.Supplier.CompanyName)
                                 .Select(g => new { Supplier = g.Key, ProductCount = g.Count(), Products = g.Select(p => p.ProductName).ToList() })
                                 .ToListAsync();
        }

        // Get api / category-product-count-with-products
        [HttpGet("category-product-count-with-products")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategoryProductCount()
        {
            return await _context.Products
                                 .GroupBy(p => p.Category.CategoryName)
                                 .Select(g => new { Category = g.Key, ProductCount = g.Count(), Products = g.Select(p => p.ProductName).ToList() })
                                 .ToListAsync();
        }
        // Get api/ suppliers-with-average-price-less-than_30
        // 26. Tìm tất cả các nhà cung cấp có sản phẩm với giá trung bình thấp hơn 30
        [HttpGet("suppliers-with-average-price-less-than-30")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliersWithAveragePriceLessThan30()
        {
            return await _context.Suppliers
                                 .Where(s => s.Products.Any(p => p.UnitPrice < 30))
                                 .ToListAsync();
        }
        // Get api / with-category-supplier-price-desc
        // 27. Lấy danh sách sản phẩm với tên danh mục và tên nhà cung cấp, sắp xếp theo giá sản phẩm giảm dần
        [HttpGet("with-category-supplier-price-desc")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategorySupplierSortedByPriceDesc()
        {
            return await _context.Products
                                 .OrderByDescending(p => p.UnitPrice)
                                 .Select(p => new { p.ProductName, CategoryName = p.Category.CategoryName, SupplierName = p.Supplier.CompanyName })
                                 .ToListAsync();
        }

        // Get api/ category-more-than-5 
        // 28. Lấy tất cả các sản phẩm thuộc về danh mục có số lượng sản phẩm nhiều hơn 5
        [HttpGet("category-more-than-5")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithCategoryMoreThan5()
        {
            return await _context.Products
                                 .Where(p => p.Category.Products.Count > 5)
                                 .ToListAsync();
        }
        // Get api / category-total-value/{categoryId}
        // 29. Tính tổng giá trị của tất cả các sản phẩm thuộc một danh mục cụ thể
        [HttpGet("category-total-value/{categoryId}")]
        public async Task<ActionResult<decimal>> GetCategoryTotalValue(int categoryId)
        {
            return await _context.Products
                                 .Where(p => p.CategoryId == categoryId)
                                 .SumAsync(p => p.UnitPrice);
        }
        //Get api / supplier-product-count/{supplierId}
        // 30. Đếm số lượng sản phẩm của một nhà cung cấp cụ thể
        [HttpGet("supplier-product-count/{supplierId}")]
        public async Task<ActionResult<object>> GetSupplierWithLowestAveragePrice()
        {
            return await _context.Suppliers
                                 .OrderBy(s => s.Products.Average(p => p.UnitPrice))
                                 .Select(s => new { s.CompanyName, AveragePrice = s.Products.Average(p => p.UnitPrice) })
                                 .FirstOrDefaultAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
