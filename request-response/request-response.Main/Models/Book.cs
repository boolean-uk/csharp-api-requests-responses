namespace api_counter.Models
{
    public class Book
    {
        private int _id;
        private string _title;
        private string _author;
        private string _genre;
        private int _numPages;

        public Book(int id, string title, string author, string genre, int numPages)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.numPages = numPages;
        }

        public int id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public string author { get { return _author; } set { _author = value; } }
        public string genre { get { return _genre; } set { _genre = value; } }
        public int numPages { get { return _numPages; } set { _numPages = value; } }
    }
}
