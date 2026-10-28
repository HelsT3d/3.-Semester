using WebAPI.Model;

namespace WebAPI.Persistence
{
    public interface IBookRepo
    {
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(int id);
        Task<List<Book>> GetAll();
        Task<Book?> GetBookById(int id);
    }
}
