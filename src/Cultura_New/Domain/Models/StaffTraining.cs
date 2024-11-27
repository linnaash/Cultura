namespace Domain.Models
{
    public partial class StaffTraining
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
