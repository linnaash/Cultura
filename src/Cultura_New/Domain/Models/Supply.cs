using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Supply
    {
        public int SupplyId { get; set; }
        public string SupplyName { get; set; } = null!;
        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; } = null!;
    }
}