using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = null!;
        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; } = null!;
    }
}