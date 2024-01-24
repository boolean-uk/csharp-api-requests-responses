using exercise.wwwapi.Data;

namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public Book(int index, string title, int pages, string author, string genre)
        {
            this.Id = index;
            this.Title = title;
            this.numPages = pages;
            this.author = author;
            this.genre = genre;
        }
    }
}
