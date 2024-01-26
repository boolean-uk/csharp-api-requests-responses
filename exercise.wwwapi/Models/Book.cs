namespace exercise.wwwapi.Models
{
    public class Book
    {
        private static int nextID = 0;

        public Book(string title = "", int numPages=0, string author = "Unknown", string genre = "")
        {
            this.Title = title;
            this.NumPages = numPages;
            this.Author = author;
            this.Genre = genre;
            this.Id = nextID++;
        }

        public int Id { get; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
