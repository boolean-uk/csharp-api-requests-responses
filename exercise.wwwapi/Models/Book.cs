namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int Id { get; set; }        // Unique identifier for the book
        public string Title { get; set; }  // Title of the book
        public int NumPages { get; set; }  // Number of pages in the book
        public string Author { get; set; } // Author of the book
        public string Genre { get; set; }  // Genre of the book
    }
}
