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
            throw new NotImplementedException();
        }

        public List<Book> getAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book getBookById(int _id)
        {
            throw new NotImplementedException();
        }

        public Book UpdateBook(BookPostPayload payload)
        {
            throw new NotImplementedException();
        }
    }
}
