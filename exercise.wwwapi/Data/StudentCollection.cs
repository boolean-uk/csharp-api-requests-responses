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

        public List<Student> GetStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            Student student = _students.FirstOrDefault(student => student.FirstName == firstName);

            return student;
        }
    };


}
