using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetPermissions()
    {
        List <Permission> permissions = _context.Permissions.ToList();
        List<PermissionDto> permissionDtos = new List<PermissionDto>();

        foreach (Permission permission in permissions)
        {
        PermissionDto myDto = new PermissionDto {Name = permission.Name, Description = permission.Description};
        permissionDtos.Add(myDto);
        }
        return Ok(permissionDtos);
    }
    [HttpPost]
    public IActionResult CreatePermissions ([FromBody] PermissionDto newPermission)
        {
            if (newPermission == null)
            {
                return BadRequest("Permission data is required");
            }

        Permission permission = new Permission
        {
            Name = newPermission.Name,
            Description = newPermission.Description
        };
        _context.Permissions.Add(permission);
        _context.SaveChanges();

        return CreatedAtAction (nameof(GetPermissions), new {id = permission.Id}, newPermission);
        }
    }
}