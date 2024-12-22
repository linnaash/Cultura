using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Event
    {
        public Event()
        {
            EmergencyPlans = new HashSet<EmergencyPlan>();
            EmployeeReports = new HashSet<EmployeeReport>();
            EmployeeWorkTimes = new HashSet<EmployeeWorkTime>();
            EventAttendances = new HashSet<EventAttendance>();
            EventFinances = new HashSet<EventFinance>();
            EventPlannings = new HashSet<EventPlanning>();
            Sponsors = new HashSet<Sponsor>();
            Volunteers = new HashSet<Volunteer>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public int EventCategoryId { get; set; }
        public int VenueId { get; set; }
        public int ResponsibleEmployeeId { get; set; }

        public virtual EventCategory EventCategory { get; set; } = null!;
        public virtual Employee ResponsibleEmployee { get; set; } = null!;
        public virtual Venue Venue { get; set; } = null!;
        public virtual ICollection<EmergencyPlan> EmergencyPlans { get; set; }
        public virtual ICollection<EmployeeReport> EmployeeReports { get; set; }
        public virtual ICollection<EmployeeWorkTime> EmployeeWorkTimes { get; set; }
        public virtual ICollection<EventAttendance> EventAttendances { get; set; }
        public virtual ICollection<EventFinance> EventFinances { get; set; }
        public virtual ICollection<EventPlanning> EventPlannings { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}