using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBookingV3.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public string Booker { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
    }
}