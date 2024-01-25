using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection : IStudent
    {
        public List<Student> _students = new List<Student>();
        private int _nextId = 1;

        public StudentCollection()
        {
            // Sample data initialization
            AddStudent(new Student { Id = 1, FirstName = "John", LastName = "Doe" });
            AddStudent(new Student { Id = 2, FirstName = "Jane", LastName = "Smith" });
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.Find(student => student.Id == id);
        }

        public Student AddStudent(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
            return student;
        }

        public bool DeleteStudent(int id)
        {
            var index = _students.FindIndex(student => student.Id == id);
            if (index == -1)
                return false;

            _students.RemoveAt(index);
            return true;
        }
    }

}
