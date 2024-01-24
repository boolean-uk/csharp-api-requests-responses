namespace exercise.wwwapi.Models
{
    public class Book
    {
        public String Title {get; set;}
        public int NumPages {get; set;}
        public string Author {get; set;}

        public string Genre {get; set;}

        public Book(string title, int numPages, string author, string genre)
        {
            Title = title;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }
    }
}
