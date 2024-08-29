
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(string name);
        T Add(T t);
        T Delete(string name);
        T Update(string name, T t);
    }
}
