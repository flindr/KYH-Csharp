using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string Booker { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
