using exercise.wwwapi.Models;
using System.Collections.Generic;

namespace exercise.wwwapi.Repositories
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T GetSingle(Func<T, bool> predicate);
        T Add(T name);
        T Update(T name);
        T Remove(Func<T, bool> predicate);
    }
}
