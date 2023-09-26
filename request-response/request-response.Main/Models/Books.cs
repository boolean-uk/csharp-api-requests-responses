namespace request_response.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }

    public class CreateBook
    {
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
