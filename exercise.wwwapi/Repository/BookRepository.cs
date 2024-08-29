using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository: IRepository<Book>
    {
        public List<Book> GetAll()
        {
            return BookCollection.getAll();
        }

        public Book GetOne(string id)
        {
            return BookCollection.getOne(id);
        }

        public Book Add(Book book)
        {
            return BookCollection.Add(book);
        }

        public Book Update(string id, Book book)
        {
            return BookCollection.Update(id, book);
        }

        public Book Delete(string id)
        {
            return BookCollection.Delete(id);
        }
    }
}
