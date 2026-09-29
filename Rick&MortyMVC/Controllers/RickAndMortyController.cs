using Microsoft.AspNetCore.Mvc;
using Rick_MortyMVC.Models;
using Rick_MortyMVC.Services;

namespace Rick_MortyMVC.Controllers
{
    public class RickAndMortyController : Controller
    {
        private readonly IRickAndMortyHttpService _rickAndMortyHttpService;

        public RickAndMortyController(IRickAndMortyHttpService rickAndMortyHttpService)
        {
            _rickAndMortyHttpService = rickAndMortyHttpService;
        }

        public IActionResult Index()
        {
            Character character = new Character();
            return View(character);
        }

        [HttpPost("/RickAndMorty/GetActionResultAsync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetActionResultAsync(int id)
        {
            Character? characterById = await _rickAndMortyHttpService.GetCharacterByIdAsync(id);
            if (characterById == null)
            {
                ViewBag.Message = "Character not found";
                return View("Index", new Character());
            }
            

            return View("Index", characterById);
            
        }
        [HttpGet ("/RickAndMorty/GetAllCharactersAsync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAllCharactersAsync()
        {
            List<Character>? characters = await _rickAndMortyHttpService.GetAllCharactersAsync();
            // Call FirstOrDefault(), and provide a fallback to a new Character if null
            return View("Index", characters.FirstOrDefault());
        }



    }
}
    