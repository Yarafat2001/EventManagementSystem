using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        [Required]
        public short Star { get; set; } // smallint translates to short

        // Foreign Key to Event
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual required Event Event { get; set; }

        // Foreign Key to User
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual required ApplicationUser User { get; set; }
    }
}