using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository:  IRepository<Book>
    {
        public void Add(Book entity)
        {
            BookCollection.Add(entity);
        }
        public bool Delete(int id)
        {
            return BookCollection.Remove(id);
        }
        public IEnumerable<Book> GetAll()
        {
            return BookCollection.getAll();
        }
        public Book GetById(int id)
        {
            return BookCollection.GetById(id);
        }
        public void Update(Book entity)
        {
            BookCollection.Update(entity);
        }

    }
}
