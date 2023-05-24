using System.ComponentModel.DataAnnotations;

namespace api_counter.Models
{
    public class Book
    {
        public Guid  Id { get; set; }

        [Required(ErrorMessage = "This field is requared")]
        public string Title { get; set; }


        [Required(ErrorMessage = "This field is requared")]
        public int NumPages { get; set; }

        [Required(ErrorMessage = "This field is requared")]
        public string Author { get; set; }

        [Required(ErrorMessage = "This field is requared")]
        public string Genre { get; set; }

    }
}
