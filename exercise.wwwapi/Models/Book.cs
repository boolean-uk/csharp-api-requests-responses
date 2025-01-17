namespace exercise.wwwapi.Models
{
    public class Book
    {
        private static int Counter = 1;
        private int id;
        private string title;
        private string author;
        private string genre;
        private int numberOfPages;

        public Book(string title, string author, string genre, int numberOfPages)
        {
            this.id = Counter++; 
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.numberOfPages = numberOfPages;
        }

        public int Id { get { return id; } }
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Genre { get { return genre; } set { genre = value; } }
        public int NumberOfPages { get { return numberOfPages; } set { numberOfPages = value; } }
    }
}
