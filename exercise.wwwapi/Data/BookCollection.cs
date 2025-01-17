using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() { Title="A Game of Thrones", NumPages=780, Author="George R.R. Martin", Genre="Fantasy" },
        };

        public static Book Add(Book book)
        {
            _books.Add(book);
            return book;
        }

        public static Book Get(string title)
        {
            return _books.FirstOrDefault(s => s.Title == title);
        }

        public static bool Remove(string title)
        {
            return _books.RemoveAll(s => s.Title == title) > 0 ? true : false;
        }

        public static Book Update(string title, Book entity)
        {
            Book book = Get(title);
            book.Title = entity.Title;
            book.NumPages = entity.NumPages;
            book.Author = entity.Author;
            book.Genre = entity.Genre;
            return book;
        }

        public static List<Book> Books { get { return _books; } }
    }
}
