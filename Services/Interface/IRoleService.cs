using MiniKFCStore.Models;

namespace MiniKFCStore.Services.Interface
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid id);
        Task CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid id);
    }
}
