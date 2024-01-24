namespace exercise.wwwapi.Data
{
    public interface IData<T>
    {
        List<T> GetAll();

        T GetByName(string name);

        public T Update(string name, T newInfo);

        public T Add(T language);

        public T Delete(string name);
    }
}
