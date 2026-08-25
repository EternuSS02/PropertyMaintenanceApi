using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class AdministrationDto
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string Address {get; set;}
        public string? Mobile {get; set;}
    }
}