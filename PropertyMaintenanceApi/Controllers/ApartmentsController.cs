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
    [HttpPost]
    public IActionResult CreateApartment([FromBody] ApartmentDto newApartment)
        {
            if (newApartment == null)
            {
                return BadRequest("Apartment data is required.");
            }

            Building? building = _context.Buildings.FirstOrDefault(b => b.Id == newApartment.Building.Id);

            Apartment apartment = new Apartment
            {
                Building = building,
                ApartmentNumber = newApartment.ApartmentNumber,
                Cubature = newApartment.Cubature,
                NoOfHabitants = newApartment.NoOfHabitants
            };
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetApartments), new { id = apartment.Id }, newApartment);
        }
    }
}