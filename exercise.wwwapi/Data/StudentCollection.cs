using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {

        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public List<Student> Get()
        {
            return _students;
        }

        public Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student Update(string firstName, Student student)
        {
            Student existingStudent = _students.FirstOrDefault(s => s.FirstName == firstName);

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;

            return student;
        }

        public Student Delete(string firstName) 
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == firstName);

            _students.Remove(student);

            return student;

        }
    }
}
