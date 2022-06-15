using HotelBookings.Console.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookings.Console
{
    public interface IBookingManagerRepository
    {
        Task AddBookingAsync(Booking newBooking);
        Task<Room> FindAsync(int room, DateTime date);
        Task<IEnumerable<Room>> FindAllAsync(DateTime date);
    }
}