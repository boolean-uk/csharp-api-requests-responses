namespace exercise.wwwapi.Models
{
    public class Book
    {
        private int id;
        private string title;
        private int numPages;
        private string author;
        private string genre;

        public Book(string title, int numPages, string author, string genre)
        {
            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
            this.id = new Random().Next(100000, 999999);
        }

        public int Id { get { return id; } }
        public string Title  { get; set; } 
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }


    }
}
