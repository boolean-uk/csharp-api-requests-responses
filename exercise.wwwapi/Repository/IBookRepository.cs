using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);

        Book UpdateBook(int id, BookPut book);
        Book DeleteBook(int id);
    }
}
