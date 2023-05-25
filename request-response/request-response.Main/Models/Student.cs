using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Student
    {
        [Required(ErrorMessage = "FirstName is a required field", AllowEmptyStrings = false)]
        [Description("This is the firstname of the person")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is a required field!", AllowEmptyStrings = false)]
        [Description("This is the lastname of the person")]
        public string LastName { get; set; }
    }
}
