using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApartmentsController(AppDbContext context)
        {
            _context = context;
        }

   [HttpGet]
public IActionResult GetApartments()
{
    List<Apartment> apartments = _context.Apartments
    .Include(a => a.Building)
    .ToList();
    List<ApartmentDto> apartmentDtos = new List<ApartmentDto>();

    foreach (Apartment apartment in apartments)
    {
        BuildingDto buildingDto = new BuildingDto
        {
            Id = apartment.Building.Id,
            Address = apartment.Building.Address
        };

        ApartmentDto myDto = new ApartmentDto
        {
            Building = buildingDto,
            ApartmentNumber = apartment.ApartmentNumber,
            Cubature = apartment.Cubature,
            NoOfHabitants = apartment.NoOfHabitants
        };

        apartmentDtos.Add(myDto);
    }

    return Ok(apartmentDtos);
}
  
    }
}