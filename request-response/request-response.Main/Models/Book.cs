namespace request_response.Models
{
    public class Book
    {
        private static int _idCounter = 0;

        public Book(String title, int numPages, string author, string genre)
        {
            Id = _idCounter++;
            Title = title;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }

        public int Id { get; set; }
        public String Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
