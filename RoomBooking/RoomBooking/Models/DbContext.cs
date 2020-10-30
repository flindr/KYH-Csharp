using System.Collections.Generic;

namespace RoomBookingV0.Models
{
    public static class DbContext
    {
        public static List<Room> Rooms { get; set; }

        static DbContext()
        {
            Rooms = new List<Room>();

            Seed();
        }

        private static void Seed()
        {
            var room1 = new Room() { Id = 1, Name = "Firelink Shrine", Floor = 1, Size = 10 };
            var room2 = new Room() { Id = 2, Name = "Irithyll", Floor = 2, Size = 6 };
            var room3 = new Room() { Id = 3, Name = "Ringed City", Floor = 3, Size = 12 };

            Rooms.Add(room1);
            Rooms.Add(room2);
            Rooms.Add(room3);
        }
    }
}
