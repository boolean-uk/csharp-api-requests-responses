using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    // repository is a class that acts as an interface for my data
    // concrete class that implements the methods (that are in the IStudentRepository
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;

        public List<Student> GetAllStudents()
        {
            return _students.Students;
        }

        public Student AddStudent(string firstName, string lastName)
        {
            return _students.AddStudent(firstName, lastName);
        }

        public Student? GetStudent(string firstName)
        {
            return _students.GetStudent(firstName);
        }

        public Student? UpdateStudent(string firstName, StudentUpdatePayload updateStudent)
        {
            var student = _students.GetStudent(firstName);
            if (student == null)
            {
                return null;
            }
            bool isUpdated = false;

            if (updateStudent.FirstName != null && updateStudent.LastName != null)
            {
                // can convert a nullable to a string
                student.FirstName = (string)updateStudent.FirstName;
                student.LastName = (string)updateStudent.LastName;
                isUpdated = true;
            }

            if (!isUpdated) throw new Exception("Student is not updated!");

            return student;
        }

        public Student DeleteStudent(string firstName)
        {
            return _students.DeleteStudent(firstName);
        }
    }
}
