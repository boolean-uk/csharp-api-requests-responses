using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student student)
        {
            return StudentCollection.Add(student);
        }

        public IEnumerable<Student> GetAll()
        { 
            return StudentCollection.GetAll();  
        }

        public Student GetOne(string name)
        {
            return StudentCollection.GetOne(name);
        }

        public Student Update(Student student, string name)
        {
            return StudentCollection.Update(name, student);
        }
        public Student Delete(string name)
        {
            return StudentCollection.Remove(name);
        }
    }
}
