using exercise.wwwapi.Models;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };
        public Student AddStudent(string firstName, string lastName)
        {
            var student = new Student() { FirstName = firstName, LastName = lastName };
            _students.Add(student);
            return student;
        }
        public Student? RemoveStudent(string firstName)
        {
            Student toBeRemoved = GetStudent(firstName);
            _students.Remove(GetStudent(firstName));
            return toBeRemoved;
        }
        public Student? GetStudent(string firstName)
        {
            return _students.FirstOrDefault(t => t.FirstName == firstName);
        }
        public List<Student> getAll()
        {
            return _students.ToList();
        }
    };
}
