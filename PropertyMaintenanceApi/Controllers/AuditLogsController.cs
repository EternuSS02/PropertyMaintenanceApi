using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditLogsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetAuditLogs()
    {
        List<AuditLog> auditLogs = _context.AuditLogs
        .Include(al => al.PerformedByUser)
        .ToList();

        List<AuditLogDto> auditLogDtos = new List<AuditLogDto>();

        foreach (AuditLog auditLog in auditLogs)
    {
        UserAuditDto performedByDto = new UserAuditDto
        {
            Name = auditLog.PerformedByUser.Name
        };

        AuditLogDto myDto = new AuditLogDto
        {
            PerformedByUserId = auditLog.PerformedByUserId,
            PerformedByUser = performedByDto,
            Timestamp = auditLog.Timestamp,
            Action = auditLog.Action,
            EntityType = auditLog.EntityType,
            EntityId = auditLog.EntityId
        };
   



    auditLogDtos.Add(myDto);
    }

    return Ok(auditLogDtos);
    }
    }
}