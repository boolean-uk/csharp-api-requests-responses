using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        public static int id { get; set; } = 0;
        public static List<Book> _books = new List<Book>();
        public static void Initialize()
        {
            _books.Add(new Book() { Title = "the hobbit", numPages = 300, author = "J.R Tolkien", genre = "Fantasy" });
        }
        public static List<Book> Add(Book book)
        {
            book.Id = id++;
            _books.Add(book);
            return _books;
        }
        public static Book Get(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }
        public static List<Book> GetAll()
        {
            {
                return _books;
            }


        }
        public static List<Book> Uppdate(int id, string title, int numPages, string author, string genre)
        {
            Book book = _books.FirstOrDefault(b => b.Id == id);
            book.Title = title;
            book.numPages = numPages;
            book.author = author;
            book.genre = genre;
            return _books;

        }
        public static List<Book> Delete(int id)
        {
            _books.RemoveAll(b => b.Id == id);
            return _books;
        }
    }
}
