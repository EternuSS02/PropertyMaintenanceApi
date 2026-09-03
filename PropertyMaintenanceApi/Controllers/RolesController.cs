using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetRoles()
    {
        List <Role> roles = _context.Roles.ToList();
        List<RoleDto> roleDtos = new List<RoleDto>();

        foreach (Role role in roles)
        {
        RoleDto myDto = new RoleDto {Name = role.Name, Description = role.Description};
        roleDtos.Add(myDto);
        }
        return Ok(roleDtos);
    }
    [HttpPost]
    public IActionResult CreateRole([FromBody] RoleDto newRole)
        {
            if (newRole == null)
            {
                return BadRequest("Role data is required.");
            }

            Role role = new Role
            {
                Name = newRole.Name,
                Description = newRole.Description
            };
            _context.Roles.Add(role);
            _context.SaveChanges();

            RoleDto createdDto = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return CreatedAtAction(nameof(GetRoles), new { id= role.Id}, createdDto);
        }
    }
}