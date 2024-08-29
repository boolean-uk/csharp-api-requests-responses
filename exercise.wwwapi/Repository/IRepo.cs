namespace exercise.wwwapi.Repository
{
    public interface IRepo<T>
    {
        List<T> getAll();
        T Add(T item);
        T Update(T item, string str);
        void Delete(string str);
        T Get(string str);

    }
}
