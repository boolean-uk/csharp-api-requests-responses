namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);
        T Get(string identifier);
        List<T> GetAll();
        T Update(T entity, string identifier);
        T Delete(string identifier);
    }
}
