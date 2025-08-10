using EventManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace EventManagementSystem.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Detail { get; set; }

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        [MaxLength(100)]
        public string? VenueName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        // Foreign Key for the owner
        public string UserOwnerId { get; set; }
        [ForeignKey("UserOwnerId")]
        public virtual ApplicationUser UserOwner { get; set; }

        public EventCategory Category { get; set; }

        // Navigation Properties
        public virtual ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}