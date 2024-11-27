namespace Domain.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Events = new HashSet<Event>();
            Resources = new HashSet<Resource>();
            StaffSchedules = new HashSet<StaffSchedule>();
            Supplies = new HashSet<Supply>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedules { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
