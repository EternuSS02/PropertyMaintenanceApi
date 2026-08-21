using System;

namespace PropertyMaintenanceApi.Models
{
    public class Contractor
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string Nip {get; set;}
        public required string Regon {get; set;}
        public required string Address {get; set;}
        public required string TypeOf {get; set;}
        public string? Krs {get; set;}
    }   
}