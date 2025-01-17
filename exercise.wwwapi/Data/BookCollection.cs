using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public static class BookCollection
{
    private static List<Book> _books = new List<Book>() 
    {
        new Book() {Title = "Readable", NumPages = 10, Author = "Some guy", genre = "Instructions", Id = 0},
        new Book() {Title = "Big book", NumPages = 10000, Author = "Some other guy", genre = "Boring", Id = 1},
        new Book() {Title = "Semi big book", NumPages = 1000, Author = "The one and only", genre = "Story", Id = 2}
    };


    public static List<Book> GetBooks()
    {
        return _books;
    }


    public static Book GetBook(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public static Book AddBook(Book book)
    {
        if (_books.Where(b => b.Title == book.Title && b.Author == book.Author).ToList().Count == 0)
        {
            int id = _books.Max(b => b.Id);
            book.Id = id;

            _books.Add(book);

            return book;
        }

        return null;
    }


    public static Book UpdateBook(int id, Book book)
    {
        try
        {
            Book bookToUpdate = _books.FirstOrDefault(b => b.Id == id);
            bookToUpdate.Author = book.Author;
            bookToUpdate.NumPages = book.NumPages;
            bookToUpdate.Title = book.Title;
            bookToUpdate.genre = book.genre;

            return book;
        }

        catch (Exception e)
        {
            return null;
        }
    }


    public static Book DeleteBook(int id)
    {
        Book book = _books.FirstOrDefault(b => b.Id == id);
        if (_books.RemoveAll(b => b.Id == id) > 0)
        {
            return book;
        }

        return null;
    }
}