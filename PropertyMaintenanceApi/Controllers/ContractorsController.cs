using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.DTOs;
using PropertyMaintenanceApi.Models;

namespace PropertyMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContractorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContractorsController(AppDbContext context)
        {
            _context = context;
        }


    [HttpGet]
    public IActionResult GetContractors()
    {
        List<Contractor> contractors = _context.Contractors.ToList();
        List<ContractorDto> contractorsDto = new List<ContractorDto>();

        foreach (Contractor contractor in contractors)
        {
            ContractorDto myDto = new ContractorDto
            {
                Name = contractor.Name,
                Address = contractor.Address,
                Nip = contractor.Nip,
                Krs = contractor.Krs,
                Regon = contractor.Regon,
                TypeOf = contractor.TypeOf
            };

            contractorsDto.Add(myDto);
        }

        return Ok(contractorsDto);
    }
    }




}