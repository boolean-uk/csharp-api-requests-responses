namespace exercise.wwwapi.Models
{
    public class Student
    {
        //public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; }

        public Student(int studentId, string firstName, string lastName)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
