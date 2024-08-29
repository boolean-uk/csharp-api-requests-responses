using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book AddClass(PayLoadBook payload)
        {

            return BookCollection.Add(payload);
        }

        public List<Book> GetClasses()
        {
            return BookCollection.GetAll();
        }

        public Book GetClass(int id)
        {
            return BookCollection.GetBook(id);
        }

        public Book UpdateClass(PayLoadBook payload, int id)
        {
            return BookCollection.UpdateBook(payload, id);
        }

        public Book DeleteClass(int id)
        {
            return BookCollection.DeleteBook(id);
        }
    }
}
