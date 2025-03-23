using E_Commerce_Application.Common.interfaces;
using E_Commerce_Domain.Entities.Products;
using E_Commerce_Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Infrastructure.Features.Products.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }
    }
}
