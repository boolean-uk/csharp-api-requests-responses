using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepo
    {
        List<Book> getAll();
        Book Get(Guid id);
        Book Add(Book book);
        void Delete(Guid id);
        Book Update(Book book, Guid id);
    }
}
