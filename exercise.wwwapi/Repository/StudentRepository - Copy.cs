using exercise.wwwapi.Models;
    using exercise.wwwapi.Models;
    using System.Collections.Generic;
    using System.Linq;
namespace exercise.wwwapi.Data
{

    public interface IBookRepository : IRepository<Book>
    {
        Book FindById(int id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly BookCollection _bookCollection;

        public BookRepository(BookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public List<Book> GetAll()
        {
            return _bookCollection.GetAll();
        }

        public Book Add(Book book)
        {
            return _bookCollection.Add(book);
        }

        public bool Delete(Book book)
        {
            return _bookCollection.Delete(book);
        }

        public Book FindById(int id)
        {
            return _bookCollection.GetAll().FirstOrDefault(book => book.Id == id);
        }
    }
}
