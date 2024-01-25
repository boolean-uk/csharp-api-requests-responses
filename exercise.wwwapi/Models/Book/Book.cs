using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Models.Book
{
    public class Book
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book(int id, BookPayload payLoad)
        {
            Id = id;
            Title = payLoad.title;
            NumPages = payLoad.numPages;
            Author = payLoad.author;
            Genre = payLoad.genre;
        }
    }
}