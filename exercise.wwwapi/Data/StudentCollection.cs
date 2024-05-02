using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        public List<Student> Students { get; set; }
        private int _studentId = 0;
        /* 
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };
        */

        public StudentCollection()
        {
            Students = new List<Student>();
            AddStudent("Rose", "Breedveld");
            AddStudent("Anne", "Veen");
        }

        public Student AddStudent(string firstName, string lastName)
        {
            _studentId++;
            var newStudent = new Student(_studentId, firstName, lastName);
            Students.Add(newStudent);
            return newStudent;
        }

        public Student? GetStudent(string firstName)
        {
            return Students.FirstOrDefault(st => st.FirstName == firstName);
        }

        public Student DeleteStudent(string firstName)
        {
            var studentToDelete = GetStudent(firstName);
            return Students.Remove(studentToDelete) ? studentToDelete : null;
        }

    };


}
