using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IRepository<Book, int>
    {
        public Book Add(Book entity)
        {
            return BookCollection.Add(entity);
        }

        public Book Delete(int id)
        {
            return BookCollection.Delete(id);
        }

        public Book Get(int id)
        {
            return BookCollection.Get(id);  
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetBooks();
        }

        public Book Update(int id, Book updated)
        {
            return BookCollection.Update(id, updated);
        }
    }
}
