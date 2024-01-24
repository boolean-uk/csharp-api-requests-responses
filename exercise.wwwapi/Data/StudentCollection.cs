using exercise.wwwapi.Models;

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

        public Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public Student Change(string firstName, Student student)
        {
            Remove(firstName);
            Add(student);
            return student;
        }

        public Student Remove(string firstName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == firstName);

            _students.Remove(student);

            return student;
        }
    };
}
