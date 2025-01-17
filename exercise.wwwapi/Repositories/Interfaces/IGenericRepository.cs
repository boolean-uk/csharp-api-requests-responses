namespace exercise.wwwapi.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Get(int id);
        T Get(Func<T, bool> condition);
        T Update(int id, T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
    }
}
