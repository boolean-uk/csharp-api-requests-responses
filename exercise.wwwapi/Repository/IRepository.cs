using System.Collections.Generic;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();

        T AddEntity(T entity);

        T GetEntity(string name);

        T RemoveEntity(string name);  

    }
}
