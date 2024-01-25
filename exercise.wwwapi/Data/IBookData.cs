using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IBookData
    {
        IEnumerable<Book> GetBooks();
        Book AddBook(Book book);
        Book UpdateBook(int id, BookPut newBook);
        Book DeleteBook (int id, out Book book);
        bool GetBook(int id, out Book book);
    }
}
