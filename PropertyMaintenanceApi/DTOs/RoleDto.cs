using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class RoleDto
    {
        public required string Name {get; set;}
        public string Description {get; set;} = string.Empty;
    }
}