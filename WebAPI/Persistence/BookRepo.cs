using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Persistence
{
    public class BookRepo : IBookRepo
    {
        private readonly DbContextWebAPI _dbContextWebAPI;

        public BookRepo(DbContextWebAPI dbContextWebAPI)
        {
            _dbContextWebAPI = dbContextWebAPI;
        }
        public async Task<Book> CreateBook(Book book)
        {
            _dbContextWebAPI.Books.Add(book);
            await _dbContextWebAPI.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(int id)
        {
           var book = await _dbContextWebAPI.Books
                .FindAsync(id);
            if(book != null)
            {
               _dbContextWebAPI.Books.Remove(book);
                await _dbContextWebAPI.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAll()
        {
            return await _dbContextWebAPI.Books
            .ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
           return await _dbContextWebAPI.Books.FindAsync(id);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _dbContextWebAPI.Books.Update(book);
            await _dbContextWebAPI.SaveChangesAsync();
            return book;
        }
    }
}
