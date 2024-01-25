using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection : IStudentData
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students.ToList();
        }

        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }
        public Student UpdateStudent(string firstName, Student student)
        {
            var target = _students.FirstOrDefault(student => student.FirstName == firstName);
            target.FirstName = student.FirstName;
            target.LastName = student.LastName;
            return target;
        }
        public Student DeleteStudent(string firstName, out Student student)
        {
            student = _students.FirstOrDefault(x => x.FirstName == firstName);
            _students.Remove(student);
            return student;
        }

        public bool GetStudent(string firstName, out Student student)
        {
            student = _students.FirstOrDefault(x => x.FirstName == firstName);
            if (student == null)
            {
                return false;
            }
            return true;
        }
    };


}
