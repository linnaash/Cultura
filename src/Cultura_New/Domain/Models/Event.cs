namespace Domain.Models
{
    public partial class Event
    {
        public Event()
        {
            EmergencyPlans = new HashSet<EmergencyPlan>();
            EventAttendances = new HashSet<EventAttendance>();
            EventFinances = new HashSet<EventFinance>();
            EventPlannings = new HashSet<EventPlanning>();
            Sponsors = new HashSet<Sponsor>();
            StaffReports = new HashSet<StaffReport>();
            StaffWorkTimes = new HashSet<StaffWorkTime>();
            Volunteers = new HashSet<Volunteer>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public int EventCategoryId { get; set; }
        public int VenueId { get; set; }
        public int ResponsibleStaffId { get; set; }

        public virtual EventCategory EventCategory { get; set; } = null!;
        public virtual Employee ResponsibleStaff { get; set; } = null!;
        public virtual Venue Venue { get; set; } = null!;
        public virtual ICollection<EmergencyPlan> EmergencyPlans { get; set; }
        public virtual ICollection<EventAttendance> EventAttendances { get; set; }
        public virtual ICollection<EventFinance> EventFinances { get; set; }
        public virtual ICollection<EventPlanning> EventPlannings { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ICollection<StaffReport> StaffReports { get; set; }
        public virtual ICollection<StaffWorkTime> StaffWorkTimes { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
