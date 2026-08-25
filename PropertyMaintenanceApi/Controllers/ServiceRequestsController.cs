using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.DTOs;
using PropertyMaintenanceApi.Models;
using Microsoft.EntityFrameworkCore;
namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceRequestsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetServiceRequests() 
    {
        List<ServiceRequest> serviceRequests = _context.ServiceRequests
            .Include(sr => sr.Apartment)
                .ThenInclude(a => a.Building)
            .ToList();
        List<ServiceRequestDto> serviceRequestsDto = new List<ServiceRequestDto>();

        foreach (ServiceRequest serviceRequest in serviceRequests)
        {

            BuildingDto buildingDto = new BuildingDto
            {
                Id = serviceRequest.Apartment.Building.Id,
                Address = serviceRequest.Apartment.Building.Address
            };

            ApartmentDto apartmentDto = new ApartmentDto
            {
                Building = buildingDto,
                ApartmentNumber = serviceRequest.Apartment.ApartmentNumber,
                Cubature = serviceRequest.Apartment.Cubature,
                NoOfHabitants = serviceRequest.Apartment.NoOfHabitants
            };

            ServiceRequestDto myDto = new ServiceRequestDto
            {
                ApartmentId = serviceRequest.ApartmentId,
                Apartment = apartmentDto,
                TypeOf = serviceRequest.TypeOf,
                DateOfRequest = serviceRequest.DateOfRequest,
                Status = serviceRequest.Status
            };

            serviceRequestsDto.Add(myDto);
        }

        return Ok(serviceRequestsDto);
    } 
    }
}