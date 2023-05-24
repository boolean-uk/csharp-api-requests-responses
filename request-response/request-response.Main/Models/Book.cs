using System.ComponentModel.DataAnnotations;

namespace api_counter.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Num pages are required.")]
        public int NumPages { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }

    }
}
