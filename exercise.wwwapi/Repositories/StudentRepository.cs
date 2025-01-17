using exercise.wwwapi.Data;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public void Add(Student entity)
        {
            StudentCollection.Add(entity);
        }

        public bool Delete(int id)
        {
            return StudentCollection.Remove(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student GetById(int id)
        {
            return StudentCollection.GetById(id);
        }

        public void Update(Student entity)
        {
            StudentCollection.Update(entity);
        }
    }
}
