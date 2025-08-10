using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Net.Sockets;

namespace EventManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // You can add custom properties here if needed, like a full name
        public string? FullName { get; set; }

        // Navigation properties
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public virtual ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
    }
}