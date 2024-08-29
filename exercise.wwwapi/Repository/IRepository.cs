namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(string name);
        T Create(T entity);
        T Update(string name, T entity);
        T Delete(string name);
    }
}
