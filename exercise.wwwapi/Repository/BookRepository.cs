using System;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class BookRepository : IBookRepository
{
    public Book AddBook(Book book)
    {
        return BookCollection.AddBook(book);
    }

    public Book DeleteBook(int id)

    {
        return BookCollection.DeleteBook(id);
    }

    public Book GetBook(int id)
    {
        return BookCollection.GetBook(id);
    }

    public IEnumerable<Book> GetBooks()
    {
        return BookCollection.GetBooks();
    }

    public Book UpdateBook(int id, Book book)
    {
        return BookCollection.UpdateBook(id, book);
    }
}
