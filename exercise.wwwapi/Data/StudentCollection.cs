using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static List<Student> Students { get => _students; }

        public static Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student GetAStudent(string firstName)
        {
            return _students.FirstOrDefault(student => student.FirstName == firstName);
        }

        public static Student UpdateStudent(string firstName, Student student)
        {
            int index = _students.FindIndex(student => student.FirstName == firstName);
            _students[index] = student;

            return student;
        }

        public static Student DeleteStudent(string firstName)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstName);
            _students.Remove(student);

            return student;
        }
    };
}
