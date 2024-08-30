namespace exercise.wwwapi.Repository
{
    public interface IBook<T> where T : class
    {
        List<T> GetAll();
        T Add(T entity);
        T Get(int id);
        T Update(T entity, int id);
        T Delete(int id);
    }
}
