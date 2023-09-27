namespace request_response.Models
{
    public class Student
    {
        public Student(String firstName, String lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
