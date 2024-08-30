using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new()
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
        
        public static Student Remove(Student student)
        {
            _students.Remove(student);
            return student;
        }
    };


}
