using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Student
    {
        //private String firstName;
        //private String lastName;

        //public Student(String firstName, String lastName)
        //{
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //}

        [Required (ErrorMessage ="Firstname is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        
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
