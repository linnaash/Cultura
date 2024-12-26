using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Supply
    {
        public int SupplyId { get; set; }
        public string? SupplyName { get; set; }
        public int? Quantity { get; set; }
        public int? EventId { get; set; }

        public virtual Event? Event { get; set; }
    }
}
