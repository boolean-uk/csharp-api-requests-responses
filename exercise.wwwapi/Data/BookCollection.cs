using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IBookCollection<Book>
    {
        private List<Book> _books = new List<Book>() {
            new Book(){Id=1, Title="A Game of Thrones", NumPages=780, Author="George R.R. Martin", Genre="Fantasy" },
            new Book(){Id=2, Title="Lord of the Rings", NumPages=867, Author="Tolkien", Genre="Fantasy"}
        };

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public Book UpdateBook(int id, Book book)
        {
            var targetBook = _books.FirstOrDefault(b => b.Id == id);
            targetBook.Id = book.Id;
            return targetBook;
        }

        public Book DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            _books.Remove(book);
            return book;
        }


    }
}
