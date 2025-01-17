namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        // Had a look at this https://www.youtube.com/watch?v=qwH5v_QaQLY
        T Add(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        T Update(int id, T entity);
        bool Delete(int id);
    }
}
