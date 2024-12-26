using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Event
    {
        public Event()
        {
            Analytics = new HashSet<Analytic>();
            EmployeeWorkTimes = new HashSet<EmployeeWorkTime>();
            EventAttendances = new HashSet<EventAttendance>();
            EventFinances = new HashSet<EventFinance>();
            EventPlannings = new HashSet<EventPlanning>();
            EventTickets = new HashSet<EventTicket>();
            Feedbacks = new HashSet<Feedback>();
            Supplies = new HashSet<Supply>();
            Volunteers = new HashSet<Volunteer>();
        }

        public int EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public int? EventCategoryId { get; set; }
        public int? ResponsibleEmployeeId { get; set; }
        public int? VenueId { get; set; }

        public virtual EventCategory? EventCategory { get; set; }
        public virtual Employee? ResponsibleEmployee { get; set; }
        public virtual Venue? Venue { get; set; }
        public virtual ICollection<Analytic> Analytics { get; set; }
        public virtual ICollection<EmployeeWorkTime> EmployeeWorkTimes { get; set; }
        public virtual ICollection<EventAttendance> EventAttendances { get; set; }
        public virtual ICollection<EventFinance> EventFinances { get; set; }
        public virtual ICollection<EventPlanning> EventPlannings { get; set; }
        public virtual ICollection<EventTicket> EventTickets { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
