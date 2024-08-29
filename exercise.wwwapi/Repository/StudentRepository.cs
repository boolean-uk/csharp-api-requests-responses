using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student CreateAStudent(Student student)
        {
            StudentCollection.CreateAStudent(student);
            return student;
        }

        public Student DeleteStudent(string firstname)
        {
            return StudentCollection.DeleteStudent(firstname);
        }

        public List<Student> GetAllStudents()
        {
            return StudentCollection.GetAllStudents();
        }

        public Student GetAStudent(string firstname)
        {
            return StudentCollection.GetAStudent(firstname);
        }

        public Student UpdateStudent(string firstname, string newFirstname, string newLastname)
        {
            return StudentCollection.UpdateStudent(firstname, newFirstname, newLastname);
        }
    }
}
