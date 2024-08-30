using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book AddBook(Book book);

        List<Book> GetAllBooks();

        Book GetBook(int id);

        Book UpdateBook(int id, Book book);

        Book DeleteBook(int id);
    }
}
