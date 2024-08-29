using exercise.wwwapi.controllers.Models;

namespace exercise.wwwapi.controllers.Data
{
    public static class StudentData
    {

        private static List<Student> _students = new List<Student>() 
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" },
            new Student() { FirstName="Deez", LastName="N." },
            new Student() { FirstName="Magnus", LastName="B" },
            new Student() { FirstName="Nobody", LastName="Knows" }
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

        public static void DeleteStudent(string firstname)
        {
            _students.Remove(_students.FirstOrDefault(stud => stud.FirstName == firstname));
        }

    }
}
