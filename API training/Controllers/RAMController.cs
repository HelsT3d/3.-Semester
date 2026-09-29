using API_training.Models;
using API_training.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_training.Controllers
{
    public class RAMController : Controller
    {
        private readonly IRAMService _RAMService;

        public RAMController(IRAMService RAMService)
        {
            _RAMService = RAMService;
        }
        public IActionResult Index()
        {
            Character character = new Character();
            return View(character);
        }
        [HttpGet]
      
        public async Task<IActionResult> GetActionResult(int id)
        {
            Character? characterById = await _RAMService.GetCharacterByIdAsync(id);
            if(characterById == null)
            {
                ViewBag.Message = "Character not found";
                return View("Index", new Character());

            }
            return View("Index", characterById);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCharacterResults()
        {
            List<Character>? characters = await _RAMService.GetAllCharactersAsync();

            return View("GetAllCharacters", characters);
        }
    }
}
