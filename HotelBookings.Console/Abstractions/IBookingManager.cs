using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookings.Console
{
    public interface IBookingManager
    {
        /**
        * Return true if there is no booking for the given room on the date,
        * otherwise false
        */
        Task<bool> IsRoomAvailableAsync(int room, DateTime date);

        /**
        * Add a booking for the given guest in the given room on the given
        * date. If the room is not available, throw a suitable Exception.
        */
        Task AddBookingAsync(string guest, int room, DateTime date);
        /**
         * Return a list of all the available room numbers for the given date
         */
        Task<IEnumerable<int>> GetAvailableRoomsAsync(DateTime date);
    }

}
