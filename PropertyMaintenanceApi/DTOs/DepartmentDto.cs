using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class DepartmentDto
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}