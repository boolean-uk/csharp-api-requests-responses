namespace exercise.wwwapi.Repository;

using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

public class BookRepository : IRepository<Book, BookViewModel>
{
    public Book Create(BookViewModel entity)
    {
        return BookCollection.Add(entity);
    }

    public Book Delete(Predicate<Book> pred)
    {
        var found = BookCollection.GetAll().Find(pred);
        BookCollection.GetAll().Remove(found);
        return found;
    }

    public Book Get(Predicate<Book> pred)
    {
        return BookCollection.GetAll().Find(pred);
    }

    public IEnumerable<Book> GetAll()
    {
        return BookCollection.GetAll();
    }

    public Book? Update(Predicate<Book> pred, BookViewModel updated)
    {
        var found = BookCollection.GetAll().Find(pred);
        if (found == null)
        {
            return null;
        }
        found.author = updated.author;
        found.numPages = updated.numPages;
        found.title = updated.title;
        found.genre = updated.genre;
        return found;
    }
}
