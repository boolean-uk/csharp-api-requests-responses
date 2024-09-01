using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        List<T> GetEntities();
        T AddEntity(T entity);
        T GetAEntity(string firstName);
        T ChangeAnEntity(T entity, string search);
        string DeleteAnEntity(string search);
        //T ChangeAnEntity(Book entity, int search);
    }
}
