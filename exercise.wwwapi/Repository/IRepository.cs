namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> 
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T GetOne(string name);
        T Update(T entity, string name);
        T Delete(string name);
    }
}
