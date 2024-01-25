using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IBookData
    {
        private List<Book> _books = new List<Book>()
        {
            new Book() { Id=1, Title="A Game of Thrones", NumPages=780, Author="George R.R. Martin", Genre="Fantasy" },
            new Book() { Id=2, Title="The Bible", NumPages=1444, Author="Multiple Unknowns", Genre="Religious" }
        };

        public List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            Book book = _books.FirstOrDefault(book => book.Id == id);

            return book;
        }

        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public Book UpdateBook(int id, BookPut book)
        {
            var target = _books.FirstOrDefault(book => book.Id == id);
            target.Title = book.Title;
            target.NumPages = book.NumPages;
            target.Author = book.Author;
            target.Genre = book.Genre;
            return target;
        }

        public Book DeleteBook(int id)
        {
            var bookToremove = _books.FirstOrDefault(book => book.Id == id);
            if (bookToremove != null)
            {
                _books.Remove(bookToremove);
                return bookToremove;
            }
            return null;
        }
    }
}
