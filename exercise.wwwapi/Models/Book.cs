namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int? Id { get; set; } //this will be set tuomatically by collection, is null until passed to collection
        public string Title { get; set; }   
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

    }
}
