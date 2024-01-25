using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        void AddBook(Book book);
        void DeleteBook(Book book);
    }
}
