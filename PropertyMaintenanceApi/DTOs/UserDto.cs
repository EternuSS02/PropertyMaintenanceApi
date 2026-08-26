using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class UserDto
    {
        public required string Name {get; set;}
        public required string Email {get; set;}
        public bool IsActive {get; set;} = true;
        public ICollection<RoleDto> Roles {get; set;} = new List<RoleDto>();
    }
}