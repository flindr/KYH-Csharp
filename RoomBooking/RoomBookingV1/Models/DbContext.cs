using System;
using System.Collections.Generic;

namespace RoomBookingV1.Models
{
    public static class DbContext
    {
        public static List<Room> Rooms { get; set; }
        public static List<Booking> Bookings { get; set; }

        static DbContext()
        {
            Rooms = new List<Room>();
            Bookings = new List<Booking>();

            Seed();
        }

        private static void Seed()
        {
            var room1 = new Room() { Id = Guid.NewGuid(), Name = "Firelink Shrine", Floor = 1, Size = 10 };
            var room2 = new Room() { Id = Guid.NewGuid(), Name = "Irithyll", Floor = 2, Size = 6 };
            var room3 = new Room() { Id = Guid.NewGuid(), Name = "Ringed City", Floor = 3, Size = 12 };

            Rooms.Add(room1);
            Rooms.Add(room2);
            Rooms.Add(room3);

            Booking booking1 = new Booking 
            { 
                Id = Guid.NewGuid(), 
                Booker = "Erik", 
                RoomId = room1.Id, 
                RoomName = room1.Name, 
                From = DateTime.Now, 
                To = DateTime.Now.AddHours(2) 
            };

            Booking booking2 = new Booking
            {
                Id = Guid.NewGuid(),
                Booker = "David",
                RoomId = room2.Id,
                RoomName = room2.Name,
                From = DateTime.Now.AddDays(1),
                To = DateTime.Now.AddDays(1).AddHours(2)
            };

            Bookings.Add(booking1);
            Bookings.Add(booking2);
        }
    }
}
