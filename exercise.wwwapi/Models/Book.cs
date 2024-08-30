namespace exercise.wwwapi.Models
{
    public class Book
    {
        private int id;
        private string title;
        private int numPages;
        private string author;
        private string genre;

        public Book(string title, int numPages, string author, string genre)
        {
            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
            this.id = new Random().Next(100000, 999999);
        }

        public int Id { get { return id; } }
        public string Title { get { return title; } set { title = value; } }
        public int NumPages { get { return numPages; } set { numPages = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Genre { get { return genre; } set { genre = value; } }


    }
}
