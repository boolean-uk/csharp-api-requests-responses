namespace exercise.wwwapi.Repositories.Interfaces
{
    public interface IGuidRepository<T>
    {
        T Get(Guid id);
        T Update(Guid id, T entity);
        bool Delete(Guid id);
        IEnumerable<T> GetAll();
        T Add(T entity);
    }
}
