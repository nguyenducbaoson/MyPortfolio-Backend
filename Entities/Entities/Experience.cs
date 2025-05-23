namespace Entities.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }
}
