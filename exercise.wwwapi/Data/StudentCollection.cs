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

        public Student? Get(string firstName)
        {
            return _students.Find(x => x.FirstName == firstName);
        }

        public Student Change(string firstName, StudentPostPayload data)
        {
            Student? student = _students.Find(x => x.FirstName == firstName);
            if (student is null) throw new Exception();
            student.FirstName = data.FirstName;
            student.LastName = data.LastName;
            return student;
        }
        public Student Delete(string firstName)
        {
            Student? student = _students.Find(x => x.FirstName == firstName);
            if (student is null) throw new Exception();
            _students.Remove(student);
            return student;
        }
    };


}
