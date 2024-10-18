using MiniKFCStore.Models;

namespace MiniKFCStore.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);

        Task<User> Authenticate(string username, string password);
        public string GenerateJwtToken(User user);
    }
}
