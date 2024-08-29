using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepo
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
            return BookCollection.Get(id);
        }

        public List<Book> getAll()
        {
            return BookCollection.getAll();
        }

        public Book Update(Book book, Guid id)
        {
            return BookCollection.Update(book, id);

        }
    }
}
