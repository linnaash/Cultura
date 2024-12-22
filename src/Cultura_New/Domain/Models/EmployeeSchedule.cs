using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeSchedule
    {
        public int ScheduleId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public int EmployeeId { get; set; }
        public int VenueId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Venue Venue { get; set; } = null!;
    }
}