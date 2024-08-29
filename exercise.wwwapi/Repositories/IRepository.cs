using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(string id);
        T Add(T entity);
        T Update(string id, T entity);
        T Delete(string id);
    }
}
