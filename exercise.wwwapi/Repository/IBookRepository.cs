namespace exercise.wwwapi.Repository
{
    public interface IBookRepository<T>
    {
        IEnumerable<T> GetAll();
        T Add(T student);
        T GetOne(int id);
        bool Delete(int id);
    }
}
