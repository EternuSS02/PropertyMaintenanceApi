using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class PermissionDto
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public string Description {get; set;} = string.Empty;
    }
}