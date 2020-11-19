using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoomBookingV3.Helpers;
using RoomBookingV3.Models;
using RoomBookingV3.Models.ViewModels;

namespace RoomBookingV3.Controllers
{
    public class BookingsController : Controller
    {
        public BookingsController()
        {

        }

        // GET: Bookings
        public IActionResult Index()
        {
            var bookings = DbContext.Bookings;

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            // vi skapar ett specifikt objekt för Create-vyn därför
            // att vi behöver en lista på alla rum som är bokbara/finns i databasen
            var createBookingViewModel = new CreateBookingViewModel() { Rooms = DbContext.Rooms };
            return View(createBookingViewModel);
        }

        // POST: Bookings/Create
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if(!ValidateBooking(booking))
            {
                var createBookingViewModel = new CreateBookingViewModel() { Rooms = DbContext.Rooms, Booking = booking };
                return View(createBookingViewModel);
            }

            // vi hämtar ut det valda rummets namn
            var roomName = DbContext.Rooms.FirstOrDefault(r => r.Id == booking.RoomId).Name;

            booking.RoomName = roomName;
            booking.Id = Guid.NewGuid();

            DbContext.Bookings.Add(booking);

            return RedirectToAction("Index");
        }

        private bool ValidateBooking(Booking booking)
        {
            bool isValid = true;

            // Check if from date is after To date
            if (booking.From > booking.To)
            {
                ModelState.AddModelError("Booking.From", "Start date cannot be after end date");
                var createBookingViewModel = new CreateBookingViewModel() { Rooms = DbContext.Rooms, Booking = booking };
                isValid = false;
            }

            //1. Hämta ut alla bokning som har samma roomId som den nya bokningen
            List<Booking> bookingsFromDb = DbContext.Bookings.Where(b => b.RoomId == booking.RoomId).ToList();

            //2. Kolla om något av dessa bokningar har överlappande datum
            foreach (var oldBooking in bookingsFromDb)
            {
                if(DateHelpers.HasSharedDateIntervals(booking.From, booking.To, oldBooking.From, oldBooking.To))
                {
                    ModelState.AddModelError("Booking.From", "Date already occupied.");
                    var createBookingViewModel = new CreateBookingViewModel() { Rooms = DbContext.Rooms, Booking = booking };
                    isValid = false;
                }
            }

            return isValid;
        }

        // GET: Bookings/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = DbContext.Bookings.FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            var editBookingViewModel = new EditBookingViewModel() { Booking = booking, Rooms = DbContext.Rooms };
            return View(editBookingViewModel);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            booking.RoomName = DbContext.Rooms.FirstOrDefault(r => r.Id == booking.RoomId).Name;

            var bookingIndex = DbContext.Bookings.FindIndex(m => m.Id == booking.Id);

            if (bookingIndex == -1)
            {
                return NotFound();
            }

            DbContext.Bookings[bookingIndex] = booking;

            return RedirectToAction(nameof(Index));
        }

        // GET: Bookings/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = DbContext.Bookings.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Bookings/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var room = DbContext.Bookings.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            DbContext.Bookings.Remove(room);

            return RedirectToAction("Index");
        }

    }
}
