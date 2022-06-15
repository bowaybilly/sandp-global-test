using HotelBookings.Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookings.Console
{
    public class HotelBookingContext : DbContext
    {
        public HotelBookingContext()
        {
            SeedData();
        }

        private void SeedData()
        {
            if (!this.Rooms.Any())
            {
                this.Rooms.AddRange((new List<Room>() {
                 new Room()
                 {
                       Id=1,
                       Created=DateTime.Now,
                       RoomNumber=101,
                 },
                 new Room()
                 {
                       Id=2,
                       Created=DateTime.Now,
                       RoomNumber=102,
                 },
                 new Room()
                 {
                       Id=3,
                       Created=DateTime.Now,
                       RoomNumber=103,
                 },


                }));

            }
            if (!this.Bookings.Any())
            {
                this.Bookings.AddRange(new List<Booking>() {
                   new Booking(){RoomId=1, RoomNumber=1, Date=DateTime.Today,            Guest="Frederick", Id=1},
                   new Booking(){RoomId=1, RoomNumber=1, Date=DateTime.Today.AddDays(1), Guest="Ross",      Id=2},
                   new Booking(){RoomId=1, RoomNumber=1, Date=DateTime.Today.AddDays(2), Guest="Angelikia", Id=3},


                });
            }
            this.SaveChanges();
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "StoreMemoryContext");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

}
