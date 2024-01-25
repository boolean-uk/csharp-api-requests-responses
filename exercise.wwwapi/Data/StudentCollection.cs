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

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        public Student GetStudent(string studentName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == studentName);
            return student;
        }

        public Student RemoveStudent(string studentName) 
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == studentName);
            _students.Remove(student);
            return student;
        }

        public Student UpdateStudent(string studentName, Student studentUpdate)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == studentName);
            student.LastName = studentUpdate.LastName;
            student.FirstName = studentUpdate.FirstName;
            return student;
        }
    };


}
