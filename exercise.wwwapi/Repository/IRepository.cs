using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Add(T student);
        T GetOne(string firstname);
        bool Delete(string firstname);
    }
}
