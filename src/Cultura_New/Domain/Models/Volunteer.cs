using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }
        public string VolunteerName { get; set; } = null!;
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}