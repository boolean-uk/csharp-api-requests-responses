using exercise.wwwapi.Models;
namespace exercise.wwwapi.Data
{
    public interface IBookDB
    {
        Book CreateObject(BookPost model);
        Book DeleteObject(int id);
        public IEnumerable<Book> GetObjects();
        Book UpdateObject(int id,BookPost model);
    }
}
