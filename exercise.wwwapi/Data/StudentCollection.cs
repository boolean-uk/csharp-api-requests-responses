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

        public static Student Add(Student student)
        {
            _students.Add(student);
            return student;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student GetOne(string firstName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName.ToLower() == firstName.ToLower());
            return student;
        }
        public static Student Remove(string firstName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName.ToLower() == firstName.ToLower());
            _students.Remove(student);
            return student;
        }

        public static Student Update(string firstName, Student update)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName.ToLower() == firstName.ToLower());
            student.FirstName = update.FirstName;
            student.LastName = update.LastName;
            return student;
        }
    };
}
