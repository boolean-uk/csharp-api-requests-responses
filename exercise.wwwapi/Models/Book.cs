namespace exercise.wwwapi.Models
{
    public class Book
    {
        private int _id;
        private string _title;
        private int _numPages;
        private string _author;
        private string _genre;

        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title;  } }
        public int NumPages { get { return _numPages; } }
        public string Author { get { return _author; } }
        public string Genre { get { return _genre; } }

        public Book(int id, string title, int numPages, string author, string genre)
        {
            _id = id;
            _title = title;
            _numPages = numPages;
            _author = author;
            _genre = genre;
        }

        public void Update(string title, int numPages, string author, string genre)
        {
            _title = title;
            _numPages = numPages;
            _author = author;
            _genre = genre;
        }
    }
}
