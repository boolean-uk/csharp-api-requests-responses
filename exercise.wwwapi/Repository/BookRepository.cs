using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        public IEnumerable<Book> GetAll()
        {
            return BookCollection.GetAll();
        }
        public Book Add(Book book)
        {
            return BookCollection.Add(book);
        }
        public Book GetOne(int id)
        {
            return BookCollection.GetOne(id);
        }
        public bool Delete(int id)
        {
            return BookCollection.Delete(id);
        }
    }
}
