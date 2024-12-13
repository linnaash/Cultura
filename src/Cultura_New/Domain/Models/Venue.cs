using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Venue
    {
        public Venue()
        {
            EmployeeSchedules = new HashSet<EmployeeSchedule>();
            Events = new HashSet<Event>();
            Resources = new HashSet<Resource>();
            Supplies = new HashSet<Supply>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
