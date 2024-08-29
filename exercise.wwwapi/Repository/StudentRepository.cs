using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student, Student, string>
    {
        public Student Add(Student entity)
        {
            return StudentCollection.Add(entity);
        }

        public Student Delete(string name)
        {
            return StudentCollection.Delete(name);
        }

        public Student Get(string firstName)
        {
            return StudentCollection.Get(firstName);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }

        public Student Update(string name, Student entity)
        {
            return StudentCollection.Update(name, entity);
        }
    }
}
