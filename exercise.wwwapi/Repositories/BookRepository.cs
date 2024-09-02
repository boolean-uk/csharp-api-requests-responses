
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository
    {
        public Book Create(Book book)
        {
            return BookCollection.Create(book);
        }
        public Book Delete(int id)
        {
            return BookCollection.Delete(id);
        }

        public Book GetA(int id)
        {
            return BookCollection.GetA(id);
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetAll();
        }

        public Book Update(Book book)
        {
            return BookCollection.Update(book);
        }
    }
}
