using System;
using System.Collections.Generic;

namespace PropertyMaintenanceApi.Models
{
    public enum ActionType 
    {
        Created,
        Updated,
        Deleted
    }
    public class AuditLog
    {
        public int Id {get; set;} 
        public int PerformedByUserId {get; set;}
        public User PerformedByUser {get; set;} = null!;
        public required DateTime Timestamp {get; set;} 
        public required ActionType Action {get; set;}
        public required string EntityType {get; set;}
        public required int EntityId {get; set;}
    }
}