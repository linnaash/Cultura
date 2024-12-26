using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Events = new HashSet<Event>();
        }

        public int VenueId { get; set; }
        public string? VenueName { get; set; }
        public string? VenueLocation { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
