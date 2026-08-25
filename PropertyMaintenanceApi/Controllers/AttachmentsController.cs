using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttachmentsController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IActionResult GetAttachments()
    {
        List<Attachment> attachments = _context.Attachments.ToList();
        List<AttachmentDto> attachmentsDto = new List <AttachmentDto>();

        foreach (Attachment attachment in attachments)
        {
            AttachmentDto myDto = new AttachmentDto
            {
                Name = attachment.Name,
                Type = attachment.Type,
                FilePath = attachment.FilePath
            };

        attachmentsDto.Add(myDto);
        }

        return Ok(attachmentsDto);
    }
    }
}