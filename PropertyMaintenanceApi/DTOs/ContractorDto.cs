using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class ContractorDto
    {
        public required string Name {get; set;}
        public required string Nip {get; set;}
        public required string Address {get; set;}
    }
}