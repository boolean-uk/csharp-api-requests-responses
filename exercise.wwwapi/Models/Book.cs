namespace exercise.wwwapi.Models
{
    public class Book
    {
        public static int id = Interlocked.Increment(ref id);

        public string title {  get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }

        public Book(string title, int numPages, string author, string genre)
        {
            id = Interlocked.Increment(ref id);

            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
        }

        //public string Title { get => _title; set => _title = value; } 
        //public int NumPages { get => _numPages; set => _numPages = value; }
        //public string Author { get => _author; set => _author = value; } 
        //public string Genre { get => _genre; set => _genre = value; }

        //public int Id { get => _id; set => _id = value; }
    }
}
