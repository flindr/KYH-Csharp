using Microsoft.AspNetCore.Mvc;
using RoomBooking.Models;
using RoomBookingV1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomBookingV1.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            List<Booking> bookings = DbContext.Bookings;
            return View(bookings);
        }

        public IActionResult Create()
        {
            CreateBookingViewModel createBookingViewModel = 
                new CreateBookingViewModel { Rooms = DbContext.Rooms };

            return View(createBookingViewModel);
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if(booking == null)
            {
                return NotFound();
            }

            Room room = DbContext.Rooms.SingleOrDefault(room => room.Id == booking.RoomId);

            if(room == null)
            {
                return NotFound();
            }

            booking.RoomName = room.Name;
            booking.Id = Guid.NewGuid();

            DbContext.Bookings.Add(booking);

            return RedirectToAction(nameof(Index));
        }
    }
}
