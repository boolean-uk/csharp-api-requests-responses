using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IRepository<T> where T : DatabaseItem 
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(string id);
        T DeleteById(string id);
    }
}
