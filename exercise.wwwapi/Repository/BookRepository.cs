using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class BookRepository : IBookRepository
{
    private IBookData _bookDatabase;

    public BookRepository(IBookData bookDatabase)
    {
        _bookDatabase = bookDatabase;
    }

    public Book AddBook(Book book)
    {
        return _bookDatabase.AddBook(book);
    }

    public IEnumerable<Book> GetBooks()
    {
        return _bookDatabase.GetBooks();
    }
    
    public Book DeleteBook(int id)
    {
        return _bookDatabase.DeleteBook(id);
    }
}
