using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using WebAPI.DTOs;
using WebAPI.Model;
using WebAPI.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;

        public BooksController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepo.GetAll();
            var response = books.Adapt<List<BookDto>>();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookById(id);
            var response = book.Adapt<BookDto>();
            if (id <= 0)
            {
                return BadRequest();
            }
            if (book != null)
            {
                return Ok(response);
            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            var response = book.Adapt<CreateBookDTO>();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            book.Id = 0;
            await _bookRepo.CreateBook(book);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ReadBookById(int id)
        {
            var book = await _bookRepo.GetBookById(id);
            var response = book.Adapt<BookDto>();
            if (id <= 0)
            {
                return BadRequest();
            }
            if (book != null)
            {
                return StatusCode(204);
            }
            return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            
            if (id <= 0)
            {
                return BadRequest();
            }
            var book = await _bookRepo.GetBookById(id);
            var response = book.Adapt<BookDto>();
            if (book == null)
            {
                return NotFound();
            }
            await _bookRepo.DeleteBook(id);
            return Ok(response);
            

        }







    }
}
