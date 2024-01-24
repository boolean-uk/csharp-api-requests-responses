namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public Book(int Id, string Title, int NumPages, string Author, string Genre)
        {
            this.id = Id;
            this.title = Title;
            this.numPages = NumPages;
            this.author = Author;
            this.genre = Genre;
        }
    }
}
