
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class Repository<T> : IRepository<T> where T : DatabaseItem
    {
        private readonly IDatabase<T> _database;

        public Repository(IDatabase<T> database)
        {
            _database = database;
        }

        public T Add(T entity)
        {
            _database.Data.Add(entity);
            return entity;
        }

        public T DeleteById(string id)
        {
            T entity = GetById(id);
            _database.Data = _database.Data.Where(x => x.Id != id).ToList();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _database.Data.ToList();
        }

        public T GetById(string id)
        {
            T entity = _database.Data.FirstOrDefault(x => x.Id.Equals(id))
                ?? throw new ArgumentException($"No item with id: {id}");
            return entity;
        }
    }
}
