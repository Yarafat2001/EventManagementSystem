using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Street { get; set; }

        [MaxLength(200)]
        public string? Address1 { get; set; }

        [MaxLength(200)]
        public string? Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public required string City { get; set; }

        [Required]
        public int Zipcode { get; set; } // mediumint can be represented by int

        // Foreign Key to User
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual required ApplicationUser User { get; set; }
    }
}