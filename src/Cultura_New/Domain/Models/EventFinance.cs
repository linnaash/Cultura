using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EventFinance
    {
        public int FinanceId { get; set; }
        public decimal Amount { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}