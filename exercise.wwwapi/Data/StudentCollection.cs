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

        public List<Student> GetAll()
        {
            return _students.ToList();
        }
        public Student GetStudent(string firstname) 
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstname);
            return student;
        }

        public Student RemoveStudent(string firstname)
        {
            var student = _students.FirstOrDefault(x =>x.FirstName == firstname);
            _students.Remove(student);
            return student;
        }
        public Student UpdateStudent(string firstname, string newName)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstname);
            _students.Remove(student);
            student.FirstName= newName;
            _students.Add(student);
            return student;
        }
    };


}
