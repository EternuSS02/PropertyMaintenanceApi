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
  
    }
}