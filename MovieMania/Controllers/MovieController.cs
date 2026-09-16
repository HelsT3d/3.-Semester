using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
using MovieMania.Persistence;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
       
        public IActionResult Index(int? MovieId)
        {
           List<Movie> movies = MovieRepository.GetAll();

            return View(movies);
        }
    }
}
