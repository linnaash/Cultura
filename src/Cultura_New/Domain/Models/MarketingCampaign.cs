using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MarketingCampaign
    {
        public int CampaignId { get; set; }
        public string? CampaignName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
