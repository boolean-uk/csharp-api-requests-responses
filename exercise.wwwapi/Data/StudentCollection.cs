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

        public Student GetStudent(string firstName)
        {
            return _students.Find(x => x.FirstName == firstName);
        }


        public Student UpdateStudent(string firstName)
        {
            Student student = _students[0];
            student.FirstName = firstName;
            return student;
        }

        public Student DeleteStudent(string firstName)
        {
            Student student = _students.Find(x => x.FirstName == firstName);
            _students.Remove(student);
            return student;
        }
    };


}
