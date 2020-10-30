using RoomBookingV1.Models;
using System.Collections.Generic;

namespace RoomBookingV1.Models.ViewModels
{
    public class EditBookingViewModel
    {
        public Booking Booking { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
