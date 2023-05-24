using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Student
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public Student()
        {

        }

    }
}
