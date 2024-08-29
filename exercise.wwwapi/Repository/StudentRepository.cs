using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Create(Student entity)
        {
            return StudentCollection.Add(entity);
        }

        public Student Delete(string identifier)
        {
            return StudentCollection.Remove(identifier);
        }

        public Student Get(string identifier)
        {
            return StudentCollection.Get(identifier);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }

        public Student Update(Student entity, string identifier)
        {
            return StudentCollection.Update(entity, identifier);
        }
    }
}
