using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoomBookingV3.Models;

namespace RoomBookingV3.Controllers
{
    public class RoomsController : Controller
    {
        public RoomsController()
        {

        }

        // GET: Rooms
        public IActionResult Index()
        {
            var rooms = DbContext.Rooms;

            return View(rooms);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        // från vyn till metoden i controllen
        public IActionResult Create(Room room)
        {
            room.Id = Guid.NewGuid();
            DbContext.Rooms.Add(room);
            return RedirectToAction("Index");
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var room = DbContext.Rooms.FirstOrDefault(r => r.Id == id);

            if(room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        public IActionResult Edit(Room room)
        {
            var roomIndex = DbContext.Rooms.FindIndex(m => m.Id == room.Id);

            if(roomIndex == -1)
            {
                return NotFound();
            }

            DbContext.Rooms[roomIndex] = room;

            return RedirectToAction(nameof(Index));
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var room = DbContext.Rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var room = DbContext.Rooms.FirstOrDefault(r => r.Id == id);

            if(room == null)
            {
                return NotFound();
            }

            DbContext.Rooms.Remove(room);

            return RedirectToAction("Index");
        }

    }
}
