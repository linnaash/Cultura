using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EventPlanning
    {
        public int PlanId { get; set; }
        public string PlanDescription { get; set; } = null!;
        public int EventId { get; set; }
        public int ResponsibleEmployeeId { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual Employee ResponsibleEmployee { get; set; } = null!;
    }
}
