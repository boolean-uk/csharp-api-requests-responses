using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public interface IBookData
{
    Book AddBook(Book book);
    List<Book> GetBooks();
    Book DeleteBook(int id);
}
