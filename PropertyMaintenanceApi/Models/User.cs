using System;
using System.Collections.Generic;

namespace PropertyMaintenanceApi.Models
{
    public class User 
    {
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? AdministrationId { get; set; }
        public Administration? Administration { get; set; }
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string Email {get; set;}
        public required string Password {get; set;}
        public required string Address {get; set;}
        public bool IsActive {get; set;} = true;
        public ICollection<Role> Roles {get; set;} = new List<Role>();
    }
}