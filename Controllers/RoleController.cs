using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniKFCStore.Models;
using MiniKFCStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniKFCStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Role>> GetRoleById(Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateRole(Role role)
        {
            await _roleService.CreateRoleAsync(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateRole(Role role)
        {
            await _roleService.UpdateRoleAsync(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteRole(Guid id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
