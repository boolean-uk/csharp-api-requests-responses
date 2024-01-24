namespace exercise.wwwapi.Models
{
    public class Book
    {
        public string _title {  get; set; }
        public int _numPages  {  get; set; }
        public string _author { get; set; }
        public string _genre { get; set; }
        public int _id { get; }

        public Book(string title, int numPages, string author, string genre, int id)
        {
            this._title = title;
            this._numPages = numPages;
            this._author = author; 
            this._genre = genre;
            this._id = id;
        }
    }
}
