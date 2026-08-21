using System;

namespace PropertyMaintenanceApi.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}