namespace exercise.wwwapi.Reposity
{
    public interface IRepository<T> where T : class
    {
        public T Add(T item); 

        public List<T> getAll();

        public T Delete(string itemName);

        public T Delete(int Id);

        public T Get(string itemName);

        public T Get(int Id);

        public T Update(string itemName, T item);

        public T Update(int Id, T item);
    }
}
