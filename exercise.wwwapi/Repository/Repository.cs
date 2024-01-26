using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Collections.Generic;
using System.Linq;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        IColl<T> _collection;

        public Repository(IColl<T> collection)
        { 
            _collection = collection;
        }

        public IEnumerable<T> Get()
        {
            return _collection.GetAll();
        }

        public T GetById(object id)
        {
            // Assuming there's a method to get by ID. You might need to adjust based on your collection's capabilities.
            return _collection.GetById(id);
        }

        public T Add(T entity)
        {
            return _collection.Add(entity);
        }

        public T Update(T entity)
        {
            // Assuming entity has an ID that can be used for finding and updating the entity.
            return _collection.Update(entity);
        }

        public object Update(object id, T entity)
        {
            // Implement logic to update entity based on id, if different from the Update(T entity) method.
            return _collection.Update(id, entity);
        }

        public T Delete(object id)
        {
            return _collection.Remove(id);
        }
    }
}
