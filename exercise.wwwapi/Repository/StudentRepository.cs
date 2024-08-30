using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student entity)
        {
            
            StudentCollection.Add(entity);
            return entity;
        }

        public List<Student> GetAll()
        {
            return StudentCollection.getAll();
        }
        public Student Get(string firstName)
        {
            return StudentCollection.Get(firstName);
        }

        public Student Update(Student newStudent, string firstName)
        {
            return StudentCollection.Update(newStudent, firstName);
        }
        public Student Delete(string firstName)
        {
            return StudentCollection.Delete(firstName);
        }
    }
}
