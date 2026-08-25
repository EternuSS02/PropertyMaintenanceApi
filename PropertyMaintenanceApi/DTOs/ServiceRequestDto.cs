using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class ServiceRequestDto
    {
        public int ApartmentId { get; set; }
        public ApartmentDto Apartment { get; set; } = null!;
        public required string TypeOf { get; set; }
        public required DateOnly DateOfRequest { get; set; } 
        public required string Status {get; set;}
    }
}