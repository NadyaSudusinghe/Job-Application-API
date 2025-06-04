namespace JobTrackerAPI.Models.DTO
{
    public class JobApplicationResponse
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime AppliedDate { get; set; }
        public string? Notes { get; set; }
    }
}
