using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class AuditLog
    {
        public int LogId { get; set; }
        public string? ModifiedBy { get; set; }
        public string? Operation { get; set; }
        public DateTime? OperationTime { get; set; }
        public string? TableName { get; set; }
    }
}
