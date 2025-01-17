using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        bool Delete(int id);
        Book AddBook(Book book);
        Book UpdateBook(int id , Book book);
    }
}
