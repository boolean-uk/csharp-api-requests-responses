using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace request_response.Models
{
    public class Language
    {
        [Required(ErrorMessage = "ProgrammingLanguage is a required field", AllowEmptyStrings = false)]
        [Description("This is the programming language")]
        public string ProgrammingLanguage { get; set; }
    }
}
