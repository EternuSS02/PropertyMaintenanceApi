using System;
using PropertyMaintenanceApi.Models;

namespace PropertyMaintenanceApi.DTOs
{
    public class AuditLogDto
    {
        public int PerformedByUserId {get; set;}
        public UserAuditDto PerformedByUser {get; set;} = null!;
        public required DateTime Timestamp {get; set;} 
        public required ActionType Action {get; set;}
        public required string EntityType {get; set;}
        public required int EntityId {get; set;}
    }
}