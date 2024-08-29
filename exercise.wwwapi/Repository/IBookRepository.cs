using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book CreateABook(Book book);
        List<Book> GetAllBooks();
        Book GetABook(int id);
        Book UpdateBook(int id, string newTitle, int newNumPages, string newAuthor, string newGenre);
        Book DeleteBook(int id);

    }
}
