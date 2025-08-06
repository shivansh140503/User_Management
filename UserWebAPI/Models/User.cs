using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebAPI.Models
{
    [Table("USERS")]
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        public required string FNAME { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string Role { get; set; }

        //public ICollection<UserActivity> Activities { get; set; }
    }
}
