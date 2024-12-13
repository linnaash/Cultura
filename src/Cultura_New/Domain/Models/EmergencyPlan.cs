using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmergencyPlan
    {
        public int PlanId { get; set; }
        public string EmergencyDescription { get; set; } = null!;
        public int EventId { get; set; }
        public int ResponsibleEmployeeId { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual Employee ResponsibleEmployee { get; set; } = null!;
    }
}
