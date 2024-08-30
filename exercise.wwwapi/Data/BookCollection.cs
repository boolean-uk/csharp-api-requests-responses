using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public static class BookCollection
{
    public static List<Book> _books = new()
    {
        new Book("Doktor Proktor", 100, "Jo Nesbø", "Comedy/Children"),
        new Book("hary Potter", 990, "JK Rowling", "Fantasy"),
    };

    public static Book Add(Book book)
    {
        _books.Add(book);
        return book;
    }

    public static List<Book> GetAll()
    {
        return _books.ToList();
    }
        
    public static Book Remove(Book book)
    {
        _books.Remove(book);
        return book;
    }
}