namespace exercise.wwwapi.Data;

using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

public static class BookCollection
{
    private static List<Book> books = new List<Book>() { };
    private static int id = 0;

    public static List<Book> GetAll()
    {
        return books;
    }

    public static Book Add(BookViewModel book)
    {
        Book b = new Book
        {
            id = id,
            title = book.title,
            numPages = book.numPages,
            author = book.author,
            genre = book.genre,
        };
        books.Add(b);
        id++;
        return b;
    }
}
