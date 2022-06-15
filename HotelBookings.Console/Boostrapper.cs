using Microsoft.Extensions.DependencyInjection;

namespace HotelBookings.Console
{
    public class Boostrapper
    {
        public static ServiceProvider Boostrap()
        {
            ServiceCollection service = new ServiceCollection();
            service.AddLogging();
            service.AddDbContext<HotelBookingContext>();
            service.AddSingleton<IBookingManager, BookingService>();
            service.AddSingleton<IBookingManagerRepository, BookingManagerRepository>();
            return service.BuildServiceProvider();
        }
    }
}