using Microsoft.AspNetCore.Mvc;
using TimeSlot.Persistence;

namespace TimeSlot.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository RoomRepository;
        public RoomsController(IRoomRepository roomRepository)
        {
            RoomRepository = roomRepository;
        }
        public IActionResult Index()
        {
            var rooms = RoomRepository.GetAll();
            return View(rooms);
        }
    }
}
