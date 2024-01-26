using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        T Add(T entity);
        IEnumerable<T> Get();
        T Update(T entity);
        object Update(object id, T entity);
        T Delete(object id);
        T GetById(object id);
    }
}
