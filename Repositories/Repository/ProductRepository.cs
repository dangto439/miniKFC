using Microsoft.EntityFrameworkCore;
using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;

namespace MiniKFCStore.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(Guid id) => await _context.Products.FindAsync(id);

        public async Task SoftDeleteAsync(Guid id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                await UpdateAsync(product);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
