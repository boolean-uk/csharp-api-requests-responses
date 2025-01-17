using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public static class BookCollection
{
    private static List<Book> _books = new List<Book>();

    public static void Initialize()
    {
        _books.Add(new Book() { Id=1, Title="The Great Gatsby", NumPages=123, Author="F. Scott Fitzgerald", Genre="Fiction" });
    }

    public static Book Add(Book book)
    {       
        book.Id = _books.Max(b => b.Id) + 1;     
        _books.Add(book);

        return book;
    }

    public static List<Book> GetAll()
    {
        return _books;
    }

    public static Book GetBook(int id)
    {
        return _books.FirstOrDefault(x => x.Id == id);
    }

    public static bool DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            return false;
        }
        _books.Remove(book);
        return true;
    }

    public static Book UpdateBook(int id, Book book)
    {
        var existingBook = _books.FirstOrDefault(x => x.Id == id);
        if (existingBook == null)
        {
            return null;
        }
        existingBook = book;
        return existingBook;
    }
}
