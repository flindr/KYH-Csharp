using System;

namespace RoomBookingV2.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public string Booker { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}