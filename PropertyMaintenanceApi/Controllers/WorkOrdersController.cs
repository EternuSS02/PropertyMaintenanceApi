using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkOrdersController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetWorkOrders()
    {
        List<WorkOrder> workOrders = _context.WorkOrders.ToList();
        List<WorkOrderDto> workOrdersDto = new List<WorkOrderDto>();

        foreach (WorkOrder workOrder in workOrders)
    {
        BuildingDto buildingDto = new BuildingDto
    {
        Id = workOrder.ServiceRequest.Apartment.Building.Id,
        Address = workOrder.ServiceRequest.Apartment.Building.Address
    };

        ApartmentDto apartmentDto = new ApartmentDto
    {
        Building = buildingDto,
        ApartmentNumber = workOrder.ServiceRequest.Apartment.ApartmentNumber,
        Cubature = workOrder.ServiceRequest.Apartment.Cubature,
        NoOfHabitants = workOrder.ServiceRequest.Apartment.NoOfHabitants
    };
    
        ServiceRequestDto serviceRequestDto = new ServiceRequestDto
    {
        Apartment = apartmentDto,
        TypeOf = workOrder.ServiceRequest.TypeOf,
        DateOfRequest = workOrder.ServiceRequest.DateOfRequest,
        Status = workOrder.ServiceRequest.Status    
    };
      UserDto? assignedUserDto = null;
      if (workOrder.AssignedUser != null)
      {

        assignedUserDto = new UserDto 
        {
            Name = workOrder.AssignedUser.Name,
            Email = workOrder.AssignedUser.Email,
            IsActive = workOrder.AssignedUser.IsActive
        };
      }

        WorkOrderDto myDto = new WorkOrderDto
        {
            ServiceRequestId = workOrder.ServiceRequestId,
            AssignedUserId = workOrder.AssignedUserId,
            ServiceRequest = serviceRequestDto,
            AssignedUser = assignedUserDto,
            Date = workOrder.Date,
            Status = workOrder.Status,
            Cost = workOrder.Cost
        };

        workOrdersDto.Add(myDto);
    }

    return Ok(workOrdersDto);
}
}
}