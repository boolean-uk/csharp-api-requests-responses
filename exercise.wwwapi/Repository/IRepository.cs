namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        T Get(string name);
        IEnumerable<T> GetAll();
        T Add(T item);
        T Update(string name, T item);
        T Delete(string name);
    }
}
