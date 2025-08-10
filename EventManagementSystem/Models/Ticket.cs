using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key to the User who owns the ticket
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual required ApplicationUser User { get; set; }

        // Foreign Key to the type of ticket purchased
        public int TicketTypeId { get; set; }
        [ForeignKey("TicketTypeId")]
        public virtual required TicketType TicketType { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    }
}