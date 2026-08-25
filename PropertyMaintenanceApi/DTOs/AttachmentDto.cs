using System;

namespace PropertyMaintenanceApi.DTOs
{
    public class AttachmentDto
    {
        public required string Name {get; set;}
        public required string Type {get; set;}
        public required string FilePath {get; set;}
    }
}