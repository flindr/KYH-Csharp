using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Models
{
    public static class DbContext
    {
        public static List<Room> Rooms { get; set; }
        
        //static DbContext()
        //{
        //    Rooms = new List<Room>();
        //}
    }
}
