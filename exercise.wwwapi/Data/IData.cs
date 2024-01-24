namespace exercise.wwwapi.Data
{
    public interface IData<T>
    {
        List<T> GetAll();

        T GetSpecific(string identifier);

        public T Update(string identifier, T newInfo);

        public T Add(T element);

        public T Delete(string identifier);
    }
}
