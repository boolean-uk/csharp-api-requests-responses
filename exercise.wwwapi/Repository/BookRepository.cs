using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IRepository<Book>
    {
        public Book AddEntity(Book entity)
        {
           return BookCollection.Add(entity);
        }

        public Book ChangeAnEntity(Book entity, string search)
        {
            var result =  BookCollection.Change(Int32.Parse(search), entity);
            return result;
        }

        
        public int DeleteAnEntity(string search)
        {
            return BookCollection.Delete(Int32.Parse(search));
        }

        public Book GetAEntity(string id)
        {
            return BookCollection.GetABook(id);
        }

        public List<Book> GetEntities()
        {
            return BookCollection.GetAll();
        }

        string IRepository<Book>.DeleteAnEntity(string search)
        {
            int id = Int32.Parse(search);
            BookCollection.Delete(id);
            return search;
        }
    }
}
