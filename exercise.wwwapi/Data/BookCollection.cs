using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IDatabase<Book>
    {
        private List<Book> _books = new List<Book>(){
            new Book()
            {
                Author="J.R.R Tolkien",
                Genre="Fantasy",
                Pages=255,
                Title="Lord of the Rings"
            },
        };
        public List<Book> Data { get { return _books; } set { _books = value; } }
    }
}
