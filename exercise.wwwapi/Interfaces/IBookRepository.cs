using exercise.wwwapi.Models;

namespace exercise.wwwapi.Interfaces
{
    public interface IBookRepository
    {
        Book Add(Book book);
        List<Book> GetAll();
        Book Get(int id);
        Book Update(int id , Book updatedBook);
        Book Delete(int id);

    }
}
