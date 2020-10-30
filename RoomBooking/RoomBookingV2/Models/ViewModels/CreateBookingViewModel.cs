using System;
using System.Collections.Generic;

namespace RoomBookingV2.Models.ViewModels
{
    public class CreateBookingViewModel
    {
        public List<Room> Rooms { get; set; }
        public Booking Booking { get; set; }
    }
}