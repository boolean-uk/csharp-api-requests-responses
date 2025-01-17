using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface IBookRepository
{
    IEnumerable<Book> GetBooks();
    Book GetBook(int id);
    bool DeleteBook(int id);
    Book AddBook(Book book);
    Book UpdateBook(int id, Book book);
}
