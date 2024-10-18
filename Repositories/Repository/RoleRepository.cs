using Microsoft.EntityFrameworkCore;
using MiniKFCStore.Data; // Thêm namespace cho DbContext
using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;

namespace MiniKFCStore.Repositories.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync() => await _context.Roles.ToListAsync();

        public async Task<Role> GetRoleByIdAsync(Guid id) => await _context.Roles.FindAsync(id);

        public async Task CreateRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await GetRoleByIdAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
