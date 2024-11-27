namespace Domain.Models
{
    public partial class Sponsor
    {
        public int SponsorId { get; set; }
        public string SponsorName { get; set; } = null!;
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}
