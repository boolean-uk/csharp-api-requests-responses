namespace exercise.wwwapi.Repository
{
    public interface IRepo<T, Y>
    {
        List<T> getAll();
        T Add(T item);
        T Update(T item, Y type);
        void Delete(Y type);
        T Get(Y type);

    }
}
