using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EventTicket
    {
        public int TicketId { get; set; }
        public int? EventId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public virtual Event? Event { get; set; }
    }
}
