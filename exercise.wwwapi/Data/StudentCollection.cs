using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        public List<Student> Students { get; set; }

        public StudentCollection()
        {
            Students = new List<Student>();
            Add("Nathan", "King");
            Add("Dave", "Ames");
            Add("John", "Doe");
        }

        public Student Add(string firstName, string lastName)
        {
            var student = new Student(firstName, lastName);
            Students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return Students.ToList();
        }

        public Student? GetStudentName(string firstname)
        {
            return Students.FirstOrDefault(s => s.FirstName == firstname);
        }
    };

}
