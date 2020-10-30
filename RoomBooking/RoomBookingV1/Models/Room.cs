using System;

namespace RoomBookingV1.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Size { get; set; }
    }
}