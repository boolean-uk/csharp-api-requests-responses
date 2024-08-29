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

        public static Student AddStudent(Student t)
        {
            _students.Add(t);
            return t;
        }

        public static Student DeleteStudent(string name)
        {
            Student student = _students.FirstOrDefault(x => x.FirstName == name) ;
            _students.Remove(student);

            return student;
        }

        public static List<Student> GetAllStudents()
        {
            return _students;
        }

        public static Student GetStudent(string name)
        {

            return _students.FirstOrDefault(x => x.FirstName == name);
        }

        public static Student UpdateStudent(string name, Student student)
        {
            var index  = _students.FindIndex(x => x.FirstName == name);
            _students[index] = student;

            return student;
        }

        
    };


}
