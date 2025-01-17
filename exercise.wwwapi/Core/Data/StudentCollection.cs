using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Extension.Books.Model;

namespace exercise.wwwapi.Core.Data
{
    public class StudentCollection
    {
        private static List<Student> _students { get; set; } = new List<Student>();
        public static void Initialize()
        {
            _students.Add(new Student() { FirstName = "Nathan", LastName = "King" });
            _students.Add(new Student() { FirstName = "Dave", LastName = "Ames" });
        }

        public Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        public bool Remove(string firstName)
        {
            return _students.RemoveAll(p => p.FirstName.Equals(firstName)) > 0 ? true : false;
        }
    };


}
