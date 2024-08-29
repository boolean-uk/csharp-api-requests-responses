namespace exercise.wwwapi.Repository
{
    public interface IRepository<T, U, S> where T : class where U : class
    {
        public List<T> GetAll();
        public T Get(S id);
        public T Add(U entity);
        public T Update(S id, U entity);
        public T Delete(S id);
    }
}
