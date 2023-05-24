using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Student
    {
        [Required (ErrorMessage ="First name is requaried")] 
        public string FirstName { get; set; }


        [Required(ErrorMessage ="Last name is requaried")] 
        public string LastName { get; set; }


        //private String firstName;
        //private String lastName;

        //public Student(String firstName, String lastName)
        //{
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //}

        //public String getFirstName()
        //{
        //    return firstName;
        //}

        //public String getLastName()
        //{
        //    return lastName;
        //}
    }
}
