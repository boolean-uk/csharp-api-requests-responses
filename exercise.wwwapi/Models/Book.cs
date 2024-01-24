
namespace exercise.wwwapi.Models
{
    public class Book
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book(string title, int numPages, string author, string genre)
        {
            Id = _nextId++;
            Title = title;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }
    }

}
