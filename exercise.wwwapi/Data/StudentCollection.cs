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

        public static Student AddStudent(Student entity)
        {        
            if (_students.Any(s => s.FirstName == entity.FirstName)) return null;  // student already exists
            _students.Add(entity);
            return entity;
        }

        public static List<Student> GetStudents()
        {
            return _students.ToList();
        }

        public static Student GetAStudent(string firstname)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstname);
            return student;
        }

        public static Student UpdateStudent(string firstname, Student entity)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstname);
            student = entity;
            return student;
        }

        public static Student DeleteStudent(string firstname)
        {
            var student = _students.Find(s => s.FirstName == firstname);
            _students.Remove(student);
            return student;
        }

    };


}
