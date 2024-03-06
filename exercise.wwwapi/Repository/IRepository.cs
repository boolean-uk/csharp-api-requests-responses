using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<T> Insert(T entity);

        Task<IEnumerable<T>> Get();

        Task<T> Update (T entity);

        Task<T> Delete(int id);

        Task<T> GetById(object id); //int id? 

        void Save();
    }
}
