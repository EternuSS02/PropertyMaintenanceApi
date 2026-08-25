using Microsoft.AspNetCore.Mvc;
using PropertyMaintenanceApi.Models;
using PropertyMaintenanceApi.DTOs;

namespace PropertyMaintenanceApi.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            List<Department> departments = _context.Departments.ToList();
            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();

            foreach(Department department in departments)
            {
                DepartmentDto myDto = new DepartmentDto
                {
                    Name = department.Name,
                    Description = department.Description
                };

                departmentDtos.Add(myDto);
            }

            return Ok(departmentDtos);
        }
    }
}