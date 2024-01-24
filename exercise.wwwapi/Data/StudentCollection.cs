using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student("Nathan", "King"),
            new Student("Dave", "Ames")
        };

        public Student AddStudent(string firstName, string lastName)
        {
            
            var newStudent = new Student(firstName, lastName);
            _students.Add(newStudent);

            return newStudent;
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public Student? GetStudent(string firstName)
        {
            return _students.Find(s => s.FirstName == firstName);
        }

        public Student? DeleteStudent(string firstName)
        {
            Student st = _students.Find(s => s.FirstName == firstName);
            _students.Remove(st);
            return st;
        }

    };


}
