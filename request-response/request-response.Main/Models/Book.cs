namespace api_counter.Models
{
    public class Book
    {
        public int _id { get; set; }
        public string _title { get; set; }
        public string _genre { get; set; }
        public string _author { get; set; }
        public int _pages { get; set; }

        public Book(int Id, string Title, string Genre, string Author, int Pages)
        {
            _id = Id;
            _title = Title;
            _genre = Genre;
            _author = Author;
            _pages = Pages;
        }
    }
}
