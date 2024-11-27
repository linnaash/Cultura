namespace Domain.Models
{
    public partial class StaffReport
    {
        public int ReportId { get; set; }
        public string ReportDescription { get; set; } = null!;
        public int EmployeeId { get; set; }
        public int? EventId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Event? Event { get; set; }
    }
}
