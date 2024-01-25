using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _database;

        public BookRepository(BookCollection BookDatabase)
        {
            _database = BookDatabase;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _database.GetAll();
        }

        public void AddBook(Book book)
        {
            _database.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _database.Delete(book);
        }
    }
}
