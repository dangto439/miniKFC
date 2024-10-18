using MiniKFCStore.Models;

namespace MiniKFCStore.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task SoftDeleteAsync(Guid id);
        Task<User> GetByUsername(string username);

    }
}
