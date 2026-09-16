using Microsoft.AspNetCore.Mvc;
using TimeSlot.Models;
using TimeSlot.Persistence;
using TimeSlot.Services;
using TimeSlot.ViewModels;

namespace TimeSlot.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly BookingService _bookingService;
        public BookingsController(BookingService bookingService, IRoomRepository roomRepository)
        {
            _bookingService = bookingService;
            _roomRepository = roomRepository;
        }


        public IActionResult Index()
        {
            // Use the instance field instead of static access
            var bookings = _bookingService.GetAll();
            return View(bookings);
        }

        public IActionResult Add(int? id)
        {
            ViewBag.Action = "add";

            var bookingVM = new BookingViewModel
            {
                Rooms = _roomRepository.GetAll()
            };

            var date = DateTime.Now;
            bookingVM.Booking.StartTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
            bookingVM.Booking.EndTime = new DateTime(date.Year, date.Month, date.Day, date.Hour + 1, date.Minute, 0);

            if (id != null) bookingVM.Booking.RoomId = id.Value;

            return View(bookingVM);
        }
        [HttpPost]
        public IActionResult Add(BookingViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                bookingVM.Rooms = _roomRepository.GetAll();
                ViewBag.Action = "add";

                return View(bookingVM);
            }

            try
            {
                _bookingService.Add(bookingVM.Booking);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                bookingVM.Rooms = _roomRepository.GetAll();
                ViewBag.Action = "add";
                return View(bookingVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            var booking = _bookingService.GetById(id ?? 0);
            if (booking == null) return NotFound();

            BookingViewModel bookingVM = new BookingViewModel
            {
                Booking = booking,
                Rooms = _roomRepository.GetAll()
            };

            ViewBag.Action = "edit";

            return View(bookingVM);
        }
        [HttpPost]
        public IActionResult Edit(BookingViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                bookingVM.Rooms = _roomRepository.GetAll();

                ViewBag.Action = "edit";

                return View(bookingVM);
            }

            try
            {
                _bookingService.Update(bookingVM.Booking);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                bookingVM.Rooms = _roomRepository.GetAll();
                ViewBag.Action = "edit";
                return View(bookingVM);
            }
        }

        public IActionResult Delete(int id)
        {
            _bookingService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

    


