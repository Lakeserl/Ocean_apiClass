using AutoMapper;
using Bai4_1721030651_VuDinhLam.Data;
using Bai4_1721030651_VuDinhLam.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai4_1721030651_VuDinhLam.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> Create(ProductDTO product);
        Task<ProductDTO> Update(ProductDTO product);
        Task Delete(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly ApiteachingContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApiteachingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.OrderDetails)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.OrderDetails)
                .FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Create(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<ProductDTO> Update(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return productDto;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
