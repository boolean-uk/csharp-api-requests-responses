using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book bookAdd(Book book);
        Book CreateBook(string title, string author, string genre, int numPage);
        Book UpdateBook(int id, string title, string author, string genre, int numPage);
        Book DeleteBook(int id);

    }
}
