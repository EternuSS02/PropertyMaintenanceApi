using System;
using System.Collections.Generic;

namespace PropertyMaintenanceApi.Models
{
    public class Attachment
    {
        public int Id {get; set;}
        public int? ServiceRequestId {get; set;}
        public ServiceRequest? ServiceRequest {get; set;}
        public int? WorkOrderId {get; set;}
        public WorkOrder? WorkOrder {get; set;}
        public required string Name {get; set;}
        public required string Type {get; set;}
        public required string FilePath {get; set;}
    }
}