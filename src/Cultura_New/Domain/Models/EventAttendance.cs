using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EventAttendance
    {
        public int AttendanceId { get; set; }
        public string AttendeeName { get; set; } = null!;
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}