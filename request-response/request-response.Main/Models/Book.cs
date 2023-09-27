namespace api_counter.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String title { get; set; }
        public int numPages { get; set; }
        public String author { get; set; }
        public String genre { get; set; }

        public Book(String title, int numPages ,String author, String genre)
        {
            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
        }

       
    }
}
