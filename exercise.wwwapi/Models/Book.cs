namespace exercise.wwwapi.Models
{
    public class Book
    {
        private int Id; 
        private string title;
        private int numPages;
        private string author;
        private string genre;


        public Book(string title, int pages, string author, string genre, int Id)
        {
            this.title = title;
            this.numPages = pages;
            this.author = author;
            this.genre = genre;
            this.Id = Id;
        }
        public string Title {get { return title; } }
        public int NumPages { get {  return numPages; } }
        public string Author { get { return author; } } 
        public string Genre { get {  return genre; } }

        public int ID { get { return Id; } }    

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetNumPages(int numPages)
        {
            this.numPages = numPages;

        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetGenre(string Genre)
        {
            this.genre = Genre;
        }

        public void SetID(int id)
        {
            Id = id;
        }
    }
}
