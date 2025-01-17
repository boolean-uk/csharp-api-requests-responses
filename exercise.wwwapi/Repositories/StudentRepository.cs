using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IRepository
    {
        public Student CreateStudent(Student student)
        {
            return StudentCollection.Add(student);
        }

        public Student DeleteStudent(string firstName)
        {
            return StudentCollection.Delete(firstName);
        }

        public Student GetStudent(string firstName)
        {
            return StudentCollection.Get(firstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.getAll();
        }

        public Student UpdateStudent(string firstName, Student updatedStudent)
        {
            return StudentCollection.Update(firstName, updatedStudent);
        }
    }
}
