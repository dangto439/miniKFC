using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;
using MiniKFCStore.Services.Interface;

namespace MiniKFCStore.Services.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository; 

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _roleRepository.GetAllRolesAsync();

        public async Task<Role> GetRoleByIdAsync(Guid id) => await _roleRepository.GetRoleByIdAsync(id);

        public async Task CreateRoleAsync(Role role) => await _roleRepository.CreateRoleAsync(role);

        public async Task UpdateRoleAsync(Role role) => await _roleRepository.UpdateRoleAsync(role);

        public async Task DeleteRoleAsync(Guid id) => await _roleRepository.DeleteRoleAsync(id);
    }
}
