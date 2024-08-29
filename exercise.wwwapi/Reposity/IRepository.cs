namespace exercise.wwwapi.Reposity
{
    public interface IRepository<T> where T : class
    {
        public T Add(T item); 

        public List<T> getAll();

        public T Delete(string itemName);

        public T Get(string itemName);

        public T Update(string itemName, T item);    
    }
}
