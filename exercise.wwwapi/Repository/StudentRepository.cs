using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student entity)
        {
            return StudentCollection.Add(entity);
        }

        public Student Delete(string name)
        {
            return StudentCollection.DeleteStudent(name);
        }

        public Student Get(string name)
        {
            return StudentCollection.GetAStudent(name);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }

        public Student Update(string name, Student entity)
        {
            return StudentCollection.UpdateStudent(name, entity);
        }
    }
}
