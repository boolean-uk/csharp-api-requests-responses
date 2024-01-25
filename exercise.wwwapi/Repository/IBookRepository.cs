using exercise.wwwapi.Models;
using static exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book AddBook(MakeBook make);
        Book GetBook(int id);

        Book UpdateBook(int id, MakeBook makeBook);

        Book DeleteBook(int id);

    }
}
