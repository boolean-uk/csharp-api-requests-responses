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

        public Student Get(string name)
        {
            return _students.FirstOrDefault(x => x.FirstName == name);
        }

        public Student Update(string name, Student student)
        {
            Student s = new();
            s = _students.FirstOrDefault(x => x.FirstName == name);
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            return s;
        }

        public void Delete(string name)
        {
            _students.Remove(_students.FirstOrDefault(x => x.FirstName == name));
        }

    };


}
