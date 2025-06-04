namespace JobTrackerAPI.Models.Domain
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime AppliedDate { get; set; }
        public string? Notes { get; set; }
    }
}
