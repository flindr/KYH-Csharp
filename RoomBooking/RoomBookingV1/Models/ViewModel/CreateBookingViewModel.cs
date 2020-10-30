using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingV1.Models.ViewModel
{
    public class CreateBookingViewModel
    {
        public Booking Booking { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
