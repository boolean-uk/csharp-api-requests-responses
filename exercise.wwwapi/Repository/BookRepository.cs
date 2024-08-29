using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IRepository<Book, BookView, int>
    {
        public Book Add(BookView entity)
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
            return BookCollection.GetAll();
        }

        public Book Update(int id, BookView entity)
        {
            return BookCollection.Update(id, entity);
        }
    }
}
