using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        public List<Student> _students = new List<Student>()
        {
            new Student() { Id = 1, FirstName="Nathan",LastName="King" },
            new Student() { Id = 2, FirstName="Dave", LastName="Ames" }
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
    };


}
