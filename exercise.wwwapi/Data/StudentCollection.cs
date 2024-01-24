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

        public void Remove(Student student)
        {
            _students.Remove(student);
        }

        public Student GetStudent(string firstName) 
        { 
            Student student = _students.Find(x => x.FirstName == firstName);

            return student;
        }
    };


}
