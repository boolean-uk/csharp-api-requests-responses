using exercise.wwwapi.Data;

namespace exercise.wwwapi.Models
{
    public class Book(int index, string title, int pages, string author, string genre)
    {
        public int Id { get; } = index;
        public string Title { get; set; } = title;
        public int numPages { get; set; } = pages;
        public string author { get; set; } = author;
        public string genre { get; set; } = genre;
    }
}
