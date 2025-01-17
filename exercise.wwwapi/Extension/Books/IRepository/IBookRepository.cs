using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Extension.Books.Model;

namespace exercise.wwwapi.Extension.Books.IRepository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetSingleBook(int id);
        Book AddBook(Book book);
        bool UpdateBook(int id, Book updatedBook);
        bool DeleteBook(int id);
    }
}
