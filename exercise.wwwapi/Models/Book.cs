namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
    }
    public class InputBook
    {
        public string title { get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
    }
}
