using MiniKFCStore.Models;

namespace MiniKFCStore.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task SoftDeleteAsync(Guid id);
    }
}
