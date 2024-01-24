using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.Payload;


namespace exercise.wwwapi.Repository {
    public class BookRepository : IBookRepository
    {
        private BookCollection _books;

        public BookRepository(BookCollection books) {
            _books = books;
        }
        public Book AddBook(string title, int numPages, string author, string genre)
        {
            Book book = new Book(title,numPages,author,genre);
            return _books.Add(book);
        }

        public Book DeleteBook(string title)
        {
            return _books.Remove(title);
        }

        public List<Book> GetAllBooks()
        {
            return _books.Books;
        }

        public Book GetBook(string title)
        {
            return _books.Get(title);
        }

        public Book UpdateBook(string title, BookUpdatePayload updateData)
        {
            Book book = _books.Get(title);
            if (book == null)
            {
                return null;
            }


            return ComparePayload(ref book, updateData);
        }

        private Book ComparePayload(ref Book book, BookUpdatePayload data)
        {
            bool hasUpdate = false;
            if (data.Title != null)
            {
                book.Title = data.Title;
                hasUpdate = true;
            }

            if (data.NumPages.HasValue)
            {
                book.NumPages = data.NumPages.Value;
                hasUpdate = true;
            }

            if (data.Author != null)
            {
                book.Author = data.Author;
                hasUpdate = true;
            }

            if (data.Genre != null)
            {
                book.Genre = data.Genre;
                hasUpdate = true;
            }
            if(!hasUpdate) throw new Exception("No update data provided");
            return book;
        }
    }
}