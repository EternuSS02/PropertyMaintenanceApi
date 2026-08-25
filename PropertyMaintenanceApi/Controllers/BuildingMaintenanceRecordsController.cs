using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingMaintenanceRecordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BuildingMaintenanceRecordsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetBuildingMaintenanceRecords()
    {
        List <BuildingMaintenanceRecord> buildingMaintenanceRecords = _context.BuildingMaintenanceRecords.ToList();
        List<BuildingMaintenanceRecordDto> buildingMaintenanceRecordDtos = new List<BuildingMaintenanceRecordDto>();

        foreach (BuildingMaintenanceRecord buildingMaintenanceRecord in buildingMaintenanceRecords)
        {
        BuildingDto buildingDto = new BuildingDto
    {
            Id = buildingMaintenanceRecord.Building.Id,
            Address = buildingMaintenanceRecord.Building.Address
    };

        BuildingMaintenanceRecordDto myDto = new BuildingMaintenanceRecordDto
    {
            Building = buildingDto,
            Date = buildingMaintenanceRecord.Date,
            Notes = buildingMaintenanceRecord.Notes,
            Type = buildingMaintenanceRecord.Type
    };

    buildingMaintenanceRecordDtos.Add(myDto);
        }
        return Ok(buildingMaintenanceRecordDtos);
    }
  
    }
}