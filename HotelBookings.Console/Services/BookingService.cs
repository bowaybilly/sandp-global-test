using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookings.Console
{
    public class BookingService : IBookingManager
    {
        public virtual IBookingManagerRepository Repository { get; }
        public virtual ILogger<BookingService> Logger { get; }

        public BookingService(IBookingManagerRepository repository,ILogger<BookingService> logger)
        {
            Repository = repository;
            Logger = logger;
        }


        public async Task AddBookingAsync(string guest, int room, DateTime date)
        {
            try
            {
                var isBookingAvailable = await this.IsRoomAvailableAsync(room, date);
                if (!isBookingAvailable)
                {
                    var newBooking = new Booking() { Guest = guest, RoomNumber = room, Date = date };
                    await this.Repository.AddBookingAsync(newBooking);
                }
                else
                {
                    throw new RoomNotAvailableException("Room not available");
                }
            }
            catch (RoomNotAvailableException ex)
            {
                Logger.LogWarning(ex.Message);
                 
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<int>> GetAvailableRoomsAsync(DateTime date)
        {
            var allRooms = await this.Repository.FindAllAsync(date);
            return await Task.FromResult(allRooms.Select(x=>x.RoomNumber));
        }

        public async Task<bool> IsRoomAvailableAsync(int room, DateTime date)
        {
            var match= await this.Repository.FindAsync(room,date);
            return match != null;
        }
    }
}
