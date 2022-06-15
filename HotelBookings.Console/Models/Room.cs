using System;
using System.Collections.Generic;

namespace HotelBookings.Console.Models
{
    public class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
