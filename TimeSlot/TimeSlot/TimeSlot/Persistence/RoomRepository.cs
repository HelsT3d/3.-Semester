using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private readonly TimeSlotContext _context;
        public RoomRepository(TimeSlotContext context)
        {
            _context = context;
        }
        public void Add(Room room)
        {
            if (room == null) return;

            _context.Rooms.Add(room);
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

        public List<Room> GetAll()
        {
            return _context.Rooms
             .Include(r => r.Bookings)
             .ToList();
        }

        public Room? GetById(int id)
        {
            return _context.Rooms
              .Include(r => r.Bookings)
              .FirstOrDefault(r => r.RoomId == id);
        }

        public void Update(Room room)
        {
            if (room == null) return;

            var existing = _context.Rooms.Find(room.RoomId);
            if (existing != null)
            {
                existing.Name = room.Name;
                existing.Capacity = room.Capacity;
                existing.RoomId = room.RoomId;
                existing.Bookings = room.Bookings;

                _context.SaveChanges();
            }
        }
    }
}

              
            
