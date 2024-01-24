namespace exercise.wwwapi.Models
{
    // Public class for Book model with properties Title, NumPage, Author, Genre
    public class Book
    {
        public string Title { get; set; }

        public int NumPage { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int Id { get; set; }
    
        public Book(int id ,string title, int numPage, string author, string genre)
        {
            Id = id;
            Title = title;
            NumPage = numPage;
            Author = author;
            Genre = genre;
        }
    }
    
}
