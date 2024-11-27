namespace Domain.Models
{
    public partial class EmergencyPlan
    {
        public int PlanId { get; set; }
        public string EmergencyDescription { get; set; } = null!;
        public int EventId { get; set; }
        public int ResponsibleStaffId { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual Employee ResponsibleStaff { get; set; } = null!;
    }
}
