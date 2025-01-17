
namespace exercise.wwwapi
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

        public Student Get(string firstName)
        {
            return _students.First(x => x.FirstName == firstName);
        }

        public Student Update(string firstName, string newFirstName, string newLastName)
        {
            Student student = _students.FirstOrDefault(x => x.FirstName == firstName);
            if (student != null)
            {
                student.FirstName = newFirstName;
                student.LastName = newLastName;
                return student;
            }
            return null;
        }

        public bool Delete(string firstName)
        {
            var studentToRemove = _students.FirstOrDefault(x => x.FirstName == firstName);
            if (studentToRemove != null)
            {
                return _students.Remove(studentToRemove);
            }
            return false;
        }
    };
}
