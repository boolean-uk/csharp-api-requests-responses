using exercise.wwwapi.Models;
using System.Linq;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" },
            new Student() { FirstName="Dave2", LastName="Ames" },
            new Student() { FirstName="Dave3", LastName="Ames" },
            new Student() { FirstName="Dave4", LastName="Ames" }
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

        public static Student Delete(string name)
        {
            Student deletedStudent = _students.First(stud => stud.FirstName == name);
            _students.Remove(deletedStudent);

            return deletedStudent;
        }
    };


}
