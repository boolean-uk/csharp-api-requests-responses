using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetOne(string query);
        T Add(T entity);
        T Update(string query, T entity);
        T Delete(string query);
    }
}
