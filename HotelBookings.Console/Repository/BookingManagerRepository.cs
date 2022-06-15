using HotelBookings.Console.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookings.Console
{
    public class BookingManagerRepository : IBookingManagerRepository
    {
        public BookingManagerRepository( ILogger<BookingManagerRepository> logger)
        {
            Logger = logger;
        }

        public virtual ILogger<BookingManagerRepository> Logger { get; }

        public async Task AddBookingAsync(Booking newBooking)
        {
            using (var ctx = new HotelBookingContext())
            {
                Logger.LogInformation("adding booking please wait");
                //find room bookings for the date specified
                var foundRoom = await FindAsync(newBooking.RoomNumber, newBooking.Date);

                if (foundRoom == null)
                {
                    // hasn't been booked, book it
                    var room = await ctx.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == newBooking.RoomNumber);
                    if (room == null) throw new InvalidRoomNumberException("Room number specified does not exist");
                     
                    newBooking.RoomId = room.Id;
                    await ctx.Bookings.AddAsync(newBooking);
                    await ctx.SaveChangesAsync();

                }
                else
                {
                    throw new RoomNotAvailableException("Room not available");
                }
            }
            
            
        }

        public async Task<IEnumerable<Room>> FindAllAsync(DateTime date)
        {
            using (var ctx = new HotelBookingContext())
            {
                var query = from rm in ctx.Set<Room>()
                            join bk in ctx.Set<Booking>()
                            on rm.RoomNumber equals bk.RoomNumber
                            //where rm.Number == room
                            where bk.Date == date
                            select rm;
                return await query.ToListAsync();
            }
           
           
        }

        public async Task<Room> FindAsync(int room, DateTime date)
        {
            using (var ctx = new HotelBookingContext())
            {
                var query = from rm in ctx.Set<Room>()
                            join bk in ctx.Set<Booking>()
                            on rm.RoomNumber equals bk.RoomNumber
                            where rm.RoomNumber == room
                            where bk.Date == date
                            select rm;
                return await query.FirstOrDefaultAsync();
            }
            

        }
    }
}
