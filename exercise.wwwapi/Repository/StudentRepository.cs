using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository<T> : IRepository<T>
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<StudentCollection> students = StudentCollection.Students;

            return students;
        }

        public T Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
