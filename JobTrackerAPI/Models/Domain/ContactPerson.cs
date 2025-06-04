namespace JobTrackerAPI.Models.Domain
{
    public class ContactPerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobApplicationId { get; set; }
    }
}
