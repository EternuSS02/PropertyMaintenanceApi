using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class WorkOrderDto
    {
        public int ServiceRequestId {get; set;}
        public ServiceRequestDto ServiceRequest {get; set;} = null!;
        public int AssignedUserId {get; set;}
        public UserDto? AssignedUser {get; set;}        public required DateOnly Date {get; set;}
        public required string Status {get; set;}
        public required decimal Cost {get; set;}
    }
}