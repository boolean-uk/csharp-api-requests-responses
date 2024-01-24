using exercise.wwwapi.Data;
using exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Repository.BookRepositories
{
    public class BookRepository : IBookRepository
    {

        private readonly BookCollection _books;

        public BookRepository(BookCollection books)
        {
            _books = books;
        }

        public Book AddBook(BookPostPayload payload)
        {
            return _books.AddBook(payload);
        }

        public void DeleteBook(int _id)
        {
            _books.DeleteBookById(_id);
        }

        public List<Book> getAllBooks()
        {
            return _books.getAllBooks();
        }

        public Book getBookById(int _id)
        {
            return _books.getBookById(_id);
        }

        public Book UpdateBook(int _id, BookPutPayload payload)
        {
            return _books.UpdateBookById(_id, payload);
        }
    }
}
