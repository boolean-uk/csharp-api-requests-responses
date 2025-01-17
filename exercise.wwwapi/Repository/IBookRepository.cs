using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        List<Book> GetAllBooks();
        Book GetBook(int id);
        Book UpdateBook(int id, string title, int numpages, string author, string genre);
        Book DeleteBook(int id);

    }
}
