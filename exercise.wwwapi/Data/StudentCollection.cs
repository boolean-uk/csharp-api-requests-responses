using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public Student Create(string firstName, string lastName)
        {
            Student student = new Student() {FirstName = firstName, LastName=lastName };
            _students.Add(student);
            return student;
        }
        public Student Remove(Student student)
        {
            _students.Remove(student);
            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }
    };


}
