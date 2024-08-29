using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book Create(BookPayload entity);
        Book Get(int identifier);
        List<Book> GetAll();
        Book Update(BookPayload entity, int identifier);
        Book Delete(int identifier);
    }
}
