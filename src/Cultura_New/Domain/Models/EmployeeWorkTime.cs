using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeWorkTime
    {
        public int WorkTimeId { get; set; }
        public int? EmployeeId { get; set; }
        public int? EventId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Event? Event { get; set; }
    }
}
