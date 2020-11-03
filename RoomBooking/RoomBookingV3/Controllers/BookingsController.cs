﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            var createBookingViewModel = new CreateBookingViewModel() { Rooms = DbContext.Rooms };
            return View(createBookingViewModel);
        }

        // POST: Bookings/Create
        [HttpPost]
        // från vyn till metoden i controllen
        public IActionResult Create(Booking booking)
        {
            var room = DbContext.Rooms.FirstOrDefault(r => r.Id == booking.RoomId);
            
            if(room == null)
            {
                return RedirectToAction(nameof(Create));
            }

            booking.Id = Guid.NewGuid();
            booking.RoomName = room.Name;

            DbContext.Bookings.Add(booking);

            return RedirectToAction("Index");
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
