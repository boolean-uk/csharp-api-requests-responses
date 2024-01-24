using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection : IStudentRepository
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {
            _students.Add(student);
            return student;
        }

        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student Update(string firstName , Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstName);
            if(student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
            }
            return student;
        }

        public Student Delete(string firstName)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstName);
            if(student != null)
            {
                _students.Remove(student);
            }
            return student;
        }
    };
}
