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

        public Student Add(string firstname, string lastname)
        {            
            Student student = new Student(firstname, lastname);
            _students.Add(student);
            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        public Student? GetStudentItem(string firstname)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstname);
        }

        public Student? DeleteStudent(string firstname) 
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstname);
            if (student != null)
            {
                
                _students.Remove(student);
                return student;
            }
            return null;
        }
    };
}
