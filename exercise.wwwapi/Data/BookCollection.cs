using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book(){ID = 1, Title = "A Game of Thrones", NumPages = 780, Author = "Gorge R.R. Martin", Genre = "Fantasy"}
        };

        public static List<Book> Books { get => _books; }

        public static Book Add(Book book)
        {
            if (_books.Any(x => x.Title == book.Title)) return null;//check if its in there?

            book.ID = _books.Max(x => x.ID) + 1; //find maximum id in collection and add 1

            _books.Add(book);

            return book;
        }

        public static List<Book> GetAll()
        {
            return _books.ToList();
        }

        public static Book GetABook(int id)
        {
            return _books.FirstOrDefault(book => book.ID == id);
        }

        public static Book UpdateBook(int id, Book book)
        {
            int index = _books.FindIndex(book => book.ID == id);
            _books[index] = book;

            return book;
        }

        public static Book DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(book => book.ID == id);
            _books.Remove(book);

            return book;
        }
    }
}
