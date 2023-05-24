using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Language
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name {get; set;}

    }
}
