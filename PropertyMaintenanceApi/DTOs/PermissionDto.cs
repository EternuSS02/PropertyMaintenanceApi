using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class PermissionDto
    {
        public required string Name {get; set;}
        public string Description {get; set;} = string.Empty;
    }
}