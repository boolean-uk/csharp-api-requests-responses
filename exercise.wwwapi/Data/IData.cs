namespace exercise.wwwapi.Data
{
    public interface IData<T>
    {
        IEnumerable<T> GetAll();
        T Get(string name);
        T Add(T item);
        T Update(string name, T item);
        T Delete(string name);

    }
}
