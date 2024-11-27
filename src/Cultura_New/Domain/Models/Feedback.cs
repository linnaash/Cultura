namespace Domain.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int EventId { get; set; }
        public string AttendeeName { get; set; } = null!;
        public string FeedbackText { get; set; } = null!;
        public int? Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
