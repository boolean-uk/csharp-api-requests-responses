using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Reposetories;

public class BookRepo : IRepository<Book, int>
{
    public Book Get(int id)
    {
        return GetAll().FirstOrDefault(b => b.Id.Equals(id));
    }

    public List<Book> GetAll()
    {
        return BookCollection.GetAll();
    }

    public Book Create(Book book)
    {
        return BookCollection.Add(book);
    }

    public Book Update(int id, Book book)
    {
        var b = Get(id);
        b.Title = book.Title;
        b.NumPages = book.NumPages;
        b.Author = book.Author;
        b.Genre = book.Genre;
        return b;
    }

    public Book Delete(Book book)
    {
        return BookCollection.Remove(book);
    }
}