using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _bookCollection;

        public BookRepository(BookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public List<Book> GetBooks()
        {
            return _bookCollection.GetBooks();
        }

        public Book AddBook(string title, int numPages, string author, string genre)
        {
            return _bookCollection.AddBook(title, numPages, author, genre);
        }
    }
}
