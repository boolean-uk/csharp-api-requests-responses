using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IRepo<Book>
    {
        public Book Add(Book book)
        {
            return BookCollection.Add(book);
        }

        public void Delete(Guid id)
        {
            BookCollection.Delete(id);
        }

        public Book Get(Guid id)
        {
            return BookCollection.GetBook(id);
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetBooks();
        }

        public Book Update(Guid id, Book newValues)
        {
            return BookCollection.Update(id, newValues);
        }
    }
}
