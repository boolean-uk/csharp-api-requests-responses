using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Add(T entity);
        T Get(string name);
        T Update(T entity, string name);
        T Delete(string name);

    }
}
