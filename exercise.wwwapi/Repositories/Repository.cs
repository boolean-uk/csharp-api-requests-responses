using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repositories
{
    public interface IRepository<T>
    {
        T Create(T info);
        List<T> GetAll();
        T GetByName(string name);
        T Update(string firstName, T newInfo);
        T Delete(string firstName);
    }
    public class Repository<T> : IRepository<T>
    {
        private IData<T> _data;

        public Repository(IData<T> data)
        {
            _data = data;
        }
        public T Create(T info)
        {
            return _data.Add(info);
        }

        public T Delete(string firstName)
        {
            return _data.Delete(firstName);
        }

        public List<T> GetAll()
        {
            return _data.GetAll();
        }

        public T GetByName(string name)
        {
            return _data.GetByName(name);
        }

        public T Update(string firstName, T newInfo)
        {
            return _data.Update(firstName, newInfo);
        }
    }
}
