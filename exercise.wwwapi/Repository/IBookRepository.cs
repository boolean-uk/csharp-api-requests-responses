using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book Add(Book entity);
        IEnumerable<Book> GetAll();
        Book Get(string title);
        Book Update(string title, Book entity);
        bool Delete(string title);
    }
}
