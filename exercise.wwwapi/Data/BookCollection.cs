using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public class BookCollection : IBookData
{
    private List<Book> _books = new List<Book>()
    {
        new Book() { Id = 1, Title = "The Hobbit", NumPages = 320, Author = "J.R.R Tolkien", Genre = "Fantasy" },
        new Book() { Id = 2, Title = "Horus Rising", NumPages = 416, Author = "Dan Abnett", Genre = "Scifi" },
        new Book() { Id = 3, Title = "Legion", NumPages = 412, Author = "Dan Abnett", Genre = "Scifi" }
    };

    public Book AddBook(Book book)
    {
        book.Id = _books.Max(car => car.Id) + 1;
        _books.Add(book);
        return book;
    }
    
    public List<Book> GetBooks()
    {
        return _books;
    }
    
    public Book DeleteBook(int id)
    {
        var toDelete = _books.FirstOrDefault(x => x.Id == id);
        if (toDelete != null)
        {
            _books.Remove(toDelete);
        }
        return toDelete;
    }
}
