using System;

namespace PropertyMaintenanceApi.Models
{
    public class Apartment 
    {
        public int Id {get; set;}
        public int BuildingId {get; set;}
        public Building Building {get; set;} = null!;
        public required string ApartmentNumber {get; set;}
        public decimal? Cubature {get; set;}
        public int? NoOfHabitants {get; set;}

    }
}