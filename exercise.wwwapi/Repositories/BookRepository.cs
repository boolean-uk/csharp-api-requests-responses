using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return BookCollection.Books;
        }
        public Book GetBook(int id)
        {
            return BookCollection.Get(id);
        }
        public Book AddBook(Book entity)
        {
            return BookCollection.Add(entity);
        }
        public Book UpdateBook(int id, Book entity)
        {
            return BookCollection.Update(id, entity);
        }
        public bool Delete(int id)
        {
            return BookCollection.Remove(id);
        }
    }
}
