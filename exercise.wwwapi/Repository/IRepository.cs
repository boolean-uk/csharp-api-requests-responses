namespace exercise.wwwapi.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Add(T student);
        bool Delete(T student);
    }
}
