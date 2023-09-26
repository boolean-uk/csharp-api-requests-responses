namespace request_response.Models
{
    public class Student
    {
        public String firstName {  get; set; }
        public String lastName { get; set; }

        public Student(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }
    }
}
