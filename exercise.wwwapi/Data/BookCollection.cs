using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books { get; set; } = new List<Book>();

        public static void Initialize()
        {
            _books.Add(new Book() { Id = 1, Title = "A Game of Thrones", NumPages = 780, Author = "George R.R. Martin", Genre = "Fantasy" });
        }

        public static Book Add(Book book)
        {
            book.Id = _books.Max(i => i.Id) + 1;
            _books.Add(book);

            return book;
        }

        public static List<Book> GetAll()
        {
            return _books;
        }

        public static Book GetOne(int id)
        {
            return _books.Find(x => x.Id == id);
        }
        public static bool Delete(int id)
        {
            return _books.RemoveAll(x => x.Id == id) > 0 ? true : false;
        }
    };
}

