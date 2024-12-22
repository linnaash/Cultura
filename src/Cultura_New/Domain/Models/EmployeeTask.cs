using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeTask
    {
        public int TaskId { get; set; }
        public string TaskDescription { get; set; } = null!;
        public int AssignedEmployeeId { get; set; }

        public virtual Employee AssignedEmployee { get; set; } = null!;
    }
}