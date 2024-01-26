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

        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student Update(string firstName, Student student)
        {
            var target = _students.FirstOrDefault(s => s.FirstName == firstName);
            target.FirstName = student.FirstName;
            target.LastName = student.LastName;
            return target;
        }

        public Student Delete(string firstName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == firstName);
            _students.Remove(student);
            return student;
        }
    };


}
