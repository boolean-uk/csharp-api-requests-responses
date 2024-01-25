using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IBookData
    {
        Book GetBook(int id);
        List<Book> GetBooks();
        Book AddBook(Book book);
        Book UpdateBook(int id, BookPut book);
        Book DeleteBook(int id);
    }
}
