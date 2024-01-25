using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        public IBookCollection<Book> _bookDatabase;

        public BookRepository(IBookCollection<Book> bookDatabase)
        {
            _bookDatabase = bookDatabase;
        }

        public Book GetBook(int id)
        {
            return _bookDatabase.GetBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDatabase.GetAllBooks();
        }

        public Book AddBook(Book book)
        {
            return _bookDatabase.AddBook(book);
        }

        public Book UpdateBook(int id, Book book) { 
            return _bookDatabase.UpdateBook(id, book);
        }

        public Book DeleteBook(int id)
        {
            return _bookDatabase.DeleteBook(id);
        }
    }
}
