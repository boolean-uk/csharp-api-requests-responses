namespace exercise.wwwapi.Models
{
    public class Book
    {
        public Book(int id, string title, string author, string genre, int numPages)
        {
            ID = id;
            Title = title;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }

        public int ID { get; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
