using HotelBookings.Console.Models;
using System;

namespace HotelBookings.Console
{
    public class Booking
    {
        public int Id { get; set; }
        public string Guest { get; set; }
        public int RoomNumber { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }

    }
}