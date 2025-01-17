using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>();

        public static void Initialize()
        {
            _books.Add(new Book() { Id = 1, Title = "A Game of Thrones", NumPages =780 , Author = "George R.R. Martin", Genre = "Fantasy" });
        }

        public static Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }
        public static List<Book> GetBooks()
        {
            return _books;
        }

        public static Book GetBook(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public static bool DeleteBook(int id)
        {
            return _books.RemoveAll(x => x.Id == id) > 0 ? true : false;
        }

    }
}
