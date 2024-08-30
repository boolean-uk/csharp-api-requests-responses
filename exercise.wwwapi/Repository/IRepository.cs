using exercise.wwwapi.Models;

namespace exercise.wwwapi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);

        List<T> GetAll();

        T Get(string firstname);

        T Update(string firstname, T entity);

        T Delete(string firstname);


        
    }
}
