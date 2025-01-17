using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository
    {        
        public Student GetStudent(string firstName)
        {
            return StudentCollection.Get(firstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.Students;
        }

        public Student AddStudent(Student student)
        {
            return StudentCollection.Add(student);
            
        }

        public bool DeleteStudent(string firstName)
        {
            return StudentCollection.DeleteStudent(firstName);
        }

        public Student UpdateStudent(string firstName, Student student)
        {
            return StudentCollection.Update(firstName, student);
        }
    }
}
