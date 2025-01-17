using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface IBookRepository
{

    public IEnumerable<Book> GetBooks();
    public Book GetBook(int id);
    public Book AddBook(Book book);
    public Book UpdateBook(int id, Book book);
    public Book DeleteBook(int id);

}
