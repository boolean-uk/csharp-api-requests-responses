using exercise.wwwapi.Models;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private StudentCollection _students;

        public StudentRepository(StudentCollection students)
        {
            _students = students;
        }

        public Student Add(Student student)
        {
            return _students.Add(student);
        }

        public Student deleteAStudent(string firstName)
        {
            return _students.deleteAStudent(firstName);
        }

        public List<Student> getAll()
        {
            return _students.getAll();
        }

        public Student getAStudent(string firstName)
        {
            return _students.getAStudent(firstName);
        }

        public Student updateStudent(string firstName, string newfirstname, string LastName)
        {
            return _students.updateStudent(firstName, newfirstname, LastName);
        }
    }
}