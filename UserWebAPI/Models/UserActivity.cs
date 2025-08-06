using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebAPI.Models
{
    [Table("USERSActivity")]
    public class UserActivity
    {
        [Key]
        public Guid ActivityID { get; set; } = Guid.NewGuid();

        public Guid UserID { get; set; }
        public required string Activity { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public required string Role { get; set; } = string.Empty;

        public User User { get; set; }
    }
}
