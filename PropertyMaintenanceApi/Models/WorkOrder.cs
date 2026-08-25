using System;
using System.Collections.Generic;

namespace PropertyMaintenanceApi.Models
{
    public class WorkOrder
    {
        public int Id {get; set;}
        public int ServiceRequestId {get; set;}
        public ServiceRequest ServiceRequest {get; set;} = null!;
        public int? ContractorId {get; set;}
        public Contractor? Contractor {get; set;}
        public int AssignedUserId {get; set;}
        public User? AssignedUser {get; set;}
        public required DateOnly Date {get; set;}
        public required string Status {get; set;}
        public required decimal Cost {get; set;}

    }
}