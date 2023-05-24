namespace request_response.Models
{
    public class Student
    {
        private string _firstName;
        private string _lastName;

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public string firstName { get { return _firstName; } set { _firstName = value; } }
        public string lastName { get { return _lastName; } set { _lastName = value; } }
    }
}
