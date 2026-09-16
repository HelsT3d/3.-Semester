using TimeSlot.Persistence;
using TimeSlot.Models;
using AspNetCoreGeneratedDocument;
using System.Xml;

namespace TimeSlot.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        public void Add(Booking booking)
        {
            Validatebooking(booking, IsUpdate: false);
            _bookingRepository.Add(booking);

        }

        public void Delete(int id)
        {
           
            _bookingRepository.Delete(id);
        }

        public List<Booking> GetAll()
        {
            return _bookingRepository.GetAll();
        }
        public Booking? GetById(int id)
        {
            return _bookingRepository.GetById(id);
        }
        public void Update(Booking booking)
        {
            Validatebooking(booking, IsUpdate: true);
            _bookingRepository.Update(booking);
        }

        private void Validatebooking(Booking booking, bool IsUpdate)
        {
            if(booking == null)
            {
                throw new ArgumentNullException (nameof(booking));
            }
            if (booking.EndTime < booking.StartTime) 
                throw new InvalidOperationException("End time has to be later than start time");
            if (booking.StartTime < DateTime.Now) 
                throw new InvalidOperationException("Start time cannot be in the past");

            var bookingsForRoom = _bookingRepository.GetAll()
                .Where(b => b.RoomId == booking.RoomId);
            if (IsUpdate)
            {
                bookingsForRoom = bookingsForRoom.Where(b => b.BookingId != booking.BookingId);
            }
            var overlap = bookingsForRoom.Any(b => booking.StartTime < b.EndTime && b.StartTime < booking.EndTime);
            if (overlap) 
                throw new InvalidOperationException("Room is not available for the selected time");


        }
    }
}
