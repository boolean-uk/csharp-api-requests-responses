using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public Book Add(Book entity)
        {
            return BookCollection.Add(entity);
        }

        public Book Delete(string id)
        {
            return BookCollection.Delete(int.Parse(id));
        }

        public Book Get(string id)
        {
            return BookCollection.Get(int.Parse(id));
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetAll();
        }

        public Book Update(string id, Book entity)
        {
            return BookCollection.Update(int.Parse(id), entity);
        }
    }
}
