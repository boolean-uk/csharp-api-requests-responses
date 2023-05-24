using System.ComponentModel.DataAnnotations;

namespace request_response.Models
{
    public class Language
    {
        [Required]
        public string Name { get; set; }
       
    }
}
