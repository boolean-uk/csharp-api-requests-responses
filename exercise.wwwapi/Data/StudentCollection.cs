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

        public static List<Student> getAll()
        {
            return _students.ToList();
        }

        public static List<Student> Students { get { return _students; } }
    };


}
