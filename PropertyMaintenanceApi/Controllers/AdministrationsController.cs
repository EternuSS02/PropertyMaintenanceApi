using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministrationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdministrationsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetAdministrations()
    {
        List <Administration> administrations = _context.Administrations.ToList();
        List<AdministrationDto> AdministrationDtos = new List<AdministrationDto>();

        foreach (Administration administration in administrations)
        {
        AdministrationDto myDto = new AdministrationDto {Name = administration.Name, Address = administration.Address, Mobile = administration.Mobile};
        AdministrationDtos.Add(myDto);
        }
        return Ok(AdministrationDtos);
    }
  
    }
}