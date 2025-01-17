namespace exercise.wwwapi.Models
{
    public class Book
    {
        public static int nextId = 1;
        public int Id { get; }
        public string title { get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public Book(string title, int numPages, string author, string genre)
        {
            this.Id = nextId++;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.numPages = numPages;
        }

    }
}
