using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBook<Book>
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
            return BookCollection.GetAll();
        }

        public Book Update(Book entity, int id)
        {
            return BookCollection.Update(entity, id);
        }
    }
}
