//using exercise.wwwapi.Models;
namespace exercise.wwwapi.Models
{
    /*
    public class StudentColletction
    {
        //Properties
        public List<Student> Students { get; set; }

        //Methods
        public void AddStudent(string firstname, string lastname)
        {
            Student student = new Student(firstname, lastname);
            Students.Add(student);
        }

        public StudentColletction()
        {
            Students = new List<Student>();
            AddStudent("Patrik", "Andersson");
            AddStudent("Benny", "Larsson");
        }
    }
    */
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
