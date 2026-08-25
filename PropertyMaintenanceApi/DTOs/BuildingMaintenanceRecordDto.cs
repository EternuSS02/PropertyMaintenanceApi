using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class BuildingMaintenanceRecordDto
    {
        public required string Type {get; set;}
        public DateOnly? Date {get; set;} 
        public string Notes {get; set;} = string.Empty;
        public BuildingDto Building {get; set;} = null!;
    }
}