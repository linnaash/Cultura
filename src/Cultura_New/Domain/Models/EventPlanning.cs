namespace Domain.Models
{
    public partial class EventPlanning
    {
        public int PlanId { get; set; }
        public string PlanDescription { get; set; } = null!;
        public int EventId { get; set; }
        public int ResponsibleStaffId { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual Employee ResponsibleStaff { get; set; } = null!;
    }
}
