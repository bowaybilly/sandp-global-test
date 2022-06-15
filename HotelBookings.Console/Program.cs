using Microsoft.Extensions.DependencyInjection;
using System;

namespace HotelBookings.Console
{
    class Program
    {
        private static ServiceProvider service;

        static void Main(string[] args)
        {
            service=  Boostrapper.Boostrap();
            
            IBookingManager bm = service.GetService<IBookingManager>();// create your manager here;
            var today = new DateTime(2012, 3, 28);
            System.Console.WriteLine(bm.IsRoomAvailableAsync(101, today)); // outputs true
            bm.AddBookingAsync("Patel", 101, today);
            System.Console.WriteLine(bm.IsRoomAvailableAsync(101, today)); // outputs false
            bm.AddBookingAsync("Li", 101, today); // throws an exception

            System.Console.WriteLine("Hello World!");
        }
    }

}
