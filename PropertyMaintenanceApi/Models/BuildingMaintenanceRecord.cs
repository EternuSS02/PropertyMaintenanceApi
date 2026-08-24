using System;
using System.Collections.Generic;

namespace PropertyMaintenanceApi.Models
{
    public class BuildingMaintenanceRecord
    {
        public int Id {get; set;}
        public required string Type {get; set;}
        public DateOnly? Date {get; set;} 
        public string Notes {get; set;} = string.Empty;
        public int BuildingId {get; set;}
        public Building Building {get; set;} = null!;

    }
}