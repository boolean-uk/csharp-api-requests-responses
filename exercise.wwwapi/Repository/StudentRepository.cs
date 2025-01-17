using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudents
    {
        public Student AddStudent(Student student)
        {
            return StudentCollection.AddStudent(student);
        }

        public Student DeleteStudent(string firstName)
        {
            return StudentCollection.DeleteStudent(firstName);
        }

        public Student GetStudent(string firstName)
        {
            return StudentCollection.GetStudent(firstName);
        }

        public List<Student> GetStudents()
        {
            return StudentCollection.GetStudents();
        }

        public Student UpdateStudent(Student student, string firstName)
        {
            return StudentCollection.UpdateStudent(student, firstName);
        }
    }
}
