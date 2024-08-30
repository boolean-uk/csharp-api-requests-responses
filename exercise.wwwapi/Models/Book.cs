namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int bookID { get; private set; }
        public string title {  get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public static int globalBookID;

        public Book(string title, int numPages, string author, string genre)
        {
            this.bookID = Interlocked.Increment(ref globalBookID);
            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
        }
    }
}
