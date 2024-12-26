using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Resource
    {
        public int ResourceId { get; set; }
        public string? ResourceName { get; set; }
        public string? ResourceType { get; set; }
    }
}
