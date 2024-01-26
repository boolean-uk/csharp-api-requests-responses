using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IBookData
    {
        List<Book> GetAll();
        Book Add(BookCreate book);
        Book Get(int id);
        Book Update(int id, BookCreate book);
        Book Delete(int id);
    }
}
