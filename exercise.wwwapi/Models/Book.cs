namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int numPages { get; set; }

        public Book(int id, string  title, int numPages, string genre, string author)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Author = author;
            this.numPages = numPages;
        }


    }
}
