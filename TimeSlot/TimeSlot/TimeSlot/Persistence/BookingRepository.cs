using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSlot.Controllers;
using TimeSlot.Data;
using TimeSlot.Models;


namespace TimeSlot.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TimeSlotContext _context;

        public BookingRepository(TimeSlotContext context)
        {
            _context = context;
        }

        public void Add(Booking booking)
        {
            if (booking == null) return;

            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        public List<Booking> GetAll()
        {
            return _context.Bookings
                .Include(b => b.Room)
                .ToList();
        }

        public Booking? GetById(int id)
        {
           return _context.Bookings
                .Include(b => b.Room)
                .FirstOrDefault(b => b.BookingId == id);
        }

        public void Update(Booking booking)
        {
            if (booking == null) return;

            var existing = _context.Bookings.Find(booking.BookingId);
            if (existing != null)
            {
                existing.Title = booking.Title;
                existing.StartTime = booking.StartTime;
                existing.EndTime = booking.EndTime;
                existing.RoomId = booking.RoomId;

                _context.SaveChanges();
            }
        }
    }
}
