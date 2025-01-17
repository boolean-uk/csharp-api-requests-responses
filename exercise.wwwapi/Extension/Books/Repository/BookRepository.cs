using exercise.wwwapi.Core.Data;
using exercise.wwwapi.Extension.Books.Data;
using exercise.wwwapi.Extension.Books.IRepository;
using exercise.wwwapi.Extension.Books.Model;

namespace exercise.wwwapi.Extension.Books.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookCollection _bookCollection;

        public BookRepository()
        {
            _bookCollection = new BookCollection(); // Initialize the student collection
        }

        public Book AddBook(Book book)
        {
            _bookCollection.Add(book);
            return book;
        }

        public Book GetSingleBook(int id)
        {
            return _bookCollection.getAll().FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookCollection.getAll();
        }

        public bool UpdateBook(int id, Book updatedBook)
        {
            var book = _bookCollection.getAll().FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                book.title = updatedBook.title;
                book.numPages = updatedBook.numPages;
                book.author = updatedBook.author;
                book.genre = updatedBook.genre;
                return true;
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            var book = _bookCollection.getAll().FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                _bookCollection.Remove(book.Id);
                return true;
            }
            return false;
        }
    }
}
