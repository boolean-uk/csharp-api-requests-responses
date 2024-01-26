using System.Collections.Generic;

namespace exercise.wwwapi.Data
{
    public interface IColl<T>
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Remove(object id);
        T Update(T entity);
        // Optionally, if you want a method to update based on id:
        T Update(object id, T entity);
    }
}
