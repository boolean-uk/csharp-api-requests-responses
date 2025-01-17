using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBook
    {
        List<Book> GetBooks();

        Book GetBook(int id);

        Book AddBook(Book book);
        Book UpdateBook(Book book, int id);
        Book DeleteBook(int id);
    }
}
