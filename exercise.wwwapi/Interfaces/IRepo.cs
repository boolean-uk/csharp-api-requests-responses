namespace exercise.wwwapi.Interfaces
{
    public interface IRepo<T>
    {
        public T Add(T t);
        public List<T> GetAll();
        public T Get(Guid t);
        public void Delete(Guid t);
        public T Update(Guid t, T tt);

    }
}
