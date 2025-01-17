using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IBook
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book CreateBook(Book book);
        Book UpdateBook(int id, Book book);
        Book DeleteBook(int id);
    }
}
