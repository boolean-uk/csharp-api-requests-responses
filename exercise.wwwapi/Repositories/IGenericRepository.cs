namespace exercise.wwwapi.Repositories
{
    public interface IGenericRepository<T>
    {
        T Get(int id);
        T Get(Func<T, bool> condition);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(int id, T entity);
        bool Delete(int id);
    }
}
