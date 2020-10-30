using Microsoft.AspNetCore.Mvc;
using RoomBookingV1.Models;
using RoomBookingV1.Models.ViewModels;
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

        public IActionResult Edit(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Booking booking = DbContext.Bookings.SingleOrDefault(b => b.Id == id);

            if(booking == null)
            {
                return NotFound();
            }

            EditBookingViewModel editBookingViewModel =
                new EditBookingViewModel { Rooms = DbContext.Rooms, Booking = booking };

            return View(editBookingViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (booking == null)
            {
                return NotFound();
            }

            Room room = DbContext.Rooms.SingleOrDefault(r => r.Id == booking.RoomId);
            if(room == null)
            {
                return NotFound();
            }
            booking.RoomName = room.Name;

            int bookingIndex = DbContext.Bookings.FindIndex(b => b.Id == booking.Id);
            if (bookingIndex == -1)
            {
                return NotFound();
            }
            DbContext.Bookings[bookingIndex] = booking;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Booking booking = DbContext.Bookings.SingleOrDefault(b => b.Id == id);

            if(booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        public IActionResult DeleteConfirmed(Booking booking)
        {
            if(booking == null)
            {
                return NotFound();
            }

            int bookingIndex = DbContext.Bookings.FindIndex(b => b.Id == booking.Id);

            if(bookingIndex == -1)
            {
                return NotFound();
            }

            DbContext.Bookings.RemoveAt(bookingIndex);

            return RedirectToAction(nameof(Index));
        }
    }
}
