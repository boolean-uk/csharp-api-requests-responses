namespace exercise.wwwapi.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        bool Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();

    }
}
