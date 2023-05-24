using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Student
    {


        [Required]
        public string firstName { get; set; }
        [Required]

        public string lastName { get; set; }

       
    }
}
