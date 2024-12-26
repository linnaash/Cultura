using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Analytic
    {
        public int AnalyticsId { get; set; }
        public int? EventId { get; set; }
        public DateTime? CalculatedAt { get; set; }
        public string? MetricName { get; set; }
        public decimal? MetricValue { get; set; }

        public virtual Event? Event { get; set; }
    }
}
