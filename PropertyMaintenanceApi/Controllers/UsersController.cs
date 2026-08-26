using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetUsers()
    {
        List<User> users = _context.Users
        .Include(u => u.Roles)
        .ToList();

        List<UserDto> userDtos = new List<UserDto>();

       foreach (User user in users)
{
    List<RoleDto> roleDtos = new List<RoleDto>();
    foreach (Role role in user.Roles)
    {
        roleDtos.Add(new RoleDto { Name = role.Name, Description = role.Description });
    }

    UserDto myDto = new UserDto
    {
        Name = user.Name,
        Email = user.Email,
        IsActive = user.IsActive,
        Roles = roleDtos
    };

    userDtos.Add(myDto);
}

return Ok(userDtos);
    }
    }
}