using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>();
        public static void Initialize()
        {
            _students.AddRange([
                new Student() { Id = 1, FirstName="Nathan",LastName="King" },
                new Student() { Id = 2, FirstName="Dave", LastName="Ames" }
            ]);
        }
        public static List<Student> Students { get { return [.. _students]; } }

        public static Student Add(Student student)
        {            
            _students.Add(student);
            return student;
        }
        public static bool Remove(Student student)
        {
            return _students.Remove(student);
        }
    };
}
