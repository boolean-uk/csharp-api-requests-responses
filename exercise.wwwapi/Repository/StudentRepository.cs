using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student Add(Student entity)
        {
            return StudentCollection.Add(entity);
        }

        public bool Delete(string firstName)
        {
            return StudentCollection.Remove(firstName);
        }

        public Student Get(string firstName)
        {
            return StudentCollection.Get(firstName);
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentCollection.Students;
        }

        public Student Update(string firstName, Student entity)
        {
            return StudentCollection.Update(firstName, entity);
        }
    }
}
