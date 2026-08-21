using System;

namespace PropertyMaintenanceApi.Models
{
    public class Building
    {
        public int Id {get; set;}
        public int AdministrationId {get; set;}
        public Administration Administration {get; set;} = null!;
        public required string Address {get; set;}
        public int? NumberOfFloors {get; set;}
        public decimal? Cubature {get; set;}
        public DateOnly? DateOfConstruction {get; set;}
        public decimal? SharesInResources {get; set;}
    }
}