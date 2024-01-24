using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private List<Book> _books;
        public BookCollection() {
            _books = new List<Book>();
        }

        public List<Book> Books {get {return _books;}}

        public Book Add(Book book) {
            _books.Add(book);
            return book;
        }

        public Book Remove(string title) {
            Book language = Get(title);
            _books.Remove(language);
            return language;
        }

        public Book? Get(string title) {
            return _books.FirstOrDefault(t => t.Title == title);
        }
    }
}
