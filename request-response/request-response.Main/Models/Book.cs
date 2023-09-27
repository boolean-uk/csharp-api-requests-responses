namespace request_response.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int numPages { get; set; }

        public Book(int id, string title, string author, string genre, int numPages)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.numPages = numPages;
        }
    }
}
