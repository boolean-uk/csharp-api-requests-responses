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

        public List<Student> GetAllStudents()
        {
            return _students.getAll();
        }

        public Student AddStudent(string firstName, string lastName)
        {
            return _students.AddStudent(firstName, lastName);
        }

        public Student? GetStudent(string firstName)
        {
            return _students.GetStudent(firstName);
        }

        public Student? UpdateStudent(string firstName, StudentUpdatePayload updateData)
        {
            var student = _students.GetStudent(firstName);
            if (student == null)
            {
                return null;
            }

            bool hasUpdate = false;

            if (updateData.firstName != null)
            {
                student.FirstName = (string)updateData.firstName;
                hasUpdate = true;
            }

            if (updateData.lastName != null)
            {
                student.LastName = (string)updateData.lastName;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");

            return student;
        }
        
        public Student? RemoveStudent(string firstName)
        {
            var student =_students.GetStudent(firstName);
            if (student == null)
            {
                return null;
            }
            if (student.FirstName != null)
            {
                _students.RemoveStudent(firstName);
            }
            return student;
        }
    }
}
