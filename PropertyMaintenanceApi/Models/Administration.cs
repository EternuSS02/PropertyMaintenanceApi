using System;

namespace PropertyMaintenanceApi.Models
{
    public class Administration
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string Address {get; set;}
        public string? Mobile {get; set;}
    }
}