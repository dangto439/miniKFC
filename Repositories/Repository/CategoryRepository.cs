using Microsoft.EntityFrameworkCore;
using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;

namespace MiniKFCStore.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(Guid id) => await _context.Categories.FindAsync(id);

        public async Task SoftDeleteAsync(Guid id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                category.IsDeleted = true;
                await UpdateAsync(category);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
