using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _books;

        public BookRepository(BookCollection books)
        {
            _books = books;
        }

        public Book CreateABook(BookPostPayload bookPost)
        {
            Book book = _books.AddBook(bookPost);
            return book;
        }

        public Book DeleteABook(int id)
        {
            Book book = GetABook(id);
            _books.RemoveABook(book);
            return book;
        }

        public Book GetABook(int id)
        {
            return _books.GetABook(id);
        }

        public List<Book> GetAllBooks()
        {
            return _books.getAllBooks();
        }

        public Book UpdateABook(int id, BookUpdateData updateData)
        {
            Book book = GetABook(id);
            return _books.UpdateABook(book, updateData);
        }
    }
}
