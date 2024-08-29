namespace exercise.wwwapi.Repository
{
    public interface IRepository<T, TKey> where T : class
    {
        List<T> GetAll();
        T Get(TKey itemname);
        T Add(T entity);
        T Update(TKey itemname, T updated);
        T Delete(TKey itemname);
    }
}
