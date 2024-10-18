using MiniKFCStore.Models;

namespace MiniKFCStore.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid id);
        Task CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid id);
    }
}
