using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student entity)
        {
            return StudentCollection.Add(entity);
        }

        public Student Delete(string firstName)
        {
            return StudentCollection.Delete(firstName);
        }

        public Student Get(string firstName)
        {
            return StudentCollection.Get(firstName);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }

        public Student Update(string firstName, Student entity)
        {
            return StudentCollection.Update(firstName, entity);
        }
    }
}
