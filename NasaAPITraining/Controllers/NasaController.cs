using Microsoft.AspNetCore.Mvc;
using NasaAPITraining.Models;
using NasaAPITraining.Services;
namespace NasaAPITraining.Controllers
{
    public class NasaController : Controller
    {
        private readonly INasaHttpService _nasaHttpService;

        public NasaController( INasaHttpService nasaHttpService) 
        {
            _nasaHttpService = nasaHttpService;
        }
        public IActionResult Index()
        {
            APOD apod = new APOD();
            return View(apod);
        }
        [HttpGet]
        public async Task<IActionResult> GetActionResult(int id)
        {
            APOD? apod = await _nasaHttpService.GetAPODByPostIdAsync(id);
            if (apod == null)
            {
                ViewBag.Message = "Couldnt find APOD by the post_id";
                return View("Index", new APOD());
            }
            return View("Index", apod);
        }
    }
}
