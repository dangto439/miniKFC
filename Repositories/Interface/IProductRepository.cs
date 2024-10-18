using MiniKFCStore.Models;

namespace MiniKFCStore.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task SoftDeleteAsync(Guid id);
    }
}
