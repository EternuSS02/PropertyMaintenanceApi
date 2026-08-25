using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class ApartmentDto
    {
        public required BuildingDto Building {get; set;}
        public required string ApartmentNumber {get; set;}
        public decimal? Cubature {get; set;}
        public int NoOfHabitants {get; set;} 
    }
}