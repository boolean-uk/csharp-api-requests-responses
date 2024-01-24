namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        public T Add(T item);
        public List<T> GetAll();
        public T Get(string itemToFind);
        public T Remove(string firstName);
    }
}
