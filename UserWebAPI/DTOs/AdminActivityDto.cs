namespace UserWebAPI.DTOs;
public class AdminActivityDto
{
    public Guid ActivityID { get; set; }
    public Guid UserID { get; set; }
    public string Name { get; set; }     // From Users table
    public string Role { get; set; }     // From Users table
    public string Activity { get; set; } // From UserActivity table
    public DateTime Timestamp { get; set; }
}
