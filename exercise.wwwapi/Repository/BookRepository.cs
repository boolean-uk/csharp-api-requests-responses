using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

namespace exercise.wwwapi.Repository
{
    public class BookRepository
    {
        public Book Add(BookPost book)
        {
            return BookCollection.Add(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return BookCollection.GetAll();
        }

        public Book GetOne(int id)
        {
            return BookCollection.GetOne(id);
        }

        public Book Update(BookPost book, int id)
        {
            return BookCollection.Update(id, book);
        }
        public Book Delete(int id)
        {
            return BookCollection.Remove(id);
        }
    }
}
