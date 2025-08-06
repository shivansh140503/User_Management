namespace UserWebAPI.Models
{
    public class UserActivityWithDetails
    {
        public Guid ActivityID { get; set; }
        public Guid UserID { get; set; }
        public string? Fname { get; set; } 
        public string? Activity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
