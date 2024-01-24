using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface IBookRepository
{
    Book AddBook(Book book);
    IEnumerable<Book> GetBooks();
    Book DeleteBook(int id);
}
