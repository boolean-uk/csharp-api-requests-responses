namespace request_response.Models
{
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
