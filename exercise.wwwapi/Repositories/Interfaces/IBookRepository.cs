using exercise.wwwapi.Models;
using exercise.wwwapi.Views;

namespace exercise.wwwapi.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(string name);
        Book? AddBook(BookView student);
        Book? UpdateBook(string name, BookView studentview);
        bool DeleteBook(string name);
    }
}
