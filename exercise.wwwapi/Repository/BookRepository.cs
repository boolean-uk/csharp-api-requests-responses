using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book Add(Book entity)
        {
            return BookCollection.Add(entity);
        }

        public bool Delete(string title)
        {
            return BookCollection.Remove(title);
        }

        public Book Get(string title)
        {
            return BookCollection.Get(title);
        }

        public IEnumerable<Book> GetAll()
        {
            return BookCollection.Books;
        }

        public Book Update(string title, Book entity)
        {
            return BookCollection.Update(title, entity);
        }
    }
}
