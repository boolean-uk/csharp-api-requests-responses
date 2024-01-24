using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
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
        public Student getByFirstName(string firstName)
        {
            return _students.FirstOrDefault(x => x.getFirstName() == firstName);
        }

        public Student UpdateStudent(string name, string firstname, string lastname)
        {
            Student student = getByFirstName(name);
            student.rename(firstname, lastname);
            return student;
        }

        public Student DeleteStudent(string name)
        {
            Student student = getByFirstName(name);
            _students.Remove(student);
            return student;
        }
    };


}
