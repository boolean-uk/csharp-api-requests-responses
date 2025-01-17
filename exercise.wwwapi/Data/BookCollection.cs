using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public class BookCollection
{
    private List<Book> _books = new List<Book>()
    {
        new Book() { Title="Harry Potter", Author="J. K. Rowling", NumPages = 300, Genre="Fantasy" },
        new Book() { Title="C# 101: An Introduction", Author="John Doe", NumPages = 1337, Genre="Educational" }
    };
    
    public Book Add(Book book)
    {
        _books.Add(book);
        return book;
    }
    
    public bool Remove(Book book)
    {
        return _books.Remove(book);
    }
    
    public List<Book> getAll()
    {
        return _books.ToList();
    }
}