using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BuildingsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetBuildings()
    {
        List <Building> buildings = _context.Buildings.ToList();
        List<BuildingDto> buildingDtos = new List<BuildingDto>();

        foreach (Building building in buildings)
        {
        BuildingDto myDto = new BuildingDto {Id = building.Id, Address = building.Address};
        buildingDtos.Add(myDto);
        }
        return Ok(buildingDtos);
    }
  
    }
}