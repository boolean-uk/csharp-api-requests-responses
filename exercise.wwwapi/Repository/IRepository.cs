namespace exercise.wwwapi.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Add(T val);
        bool Delete(T val);
    }
}
