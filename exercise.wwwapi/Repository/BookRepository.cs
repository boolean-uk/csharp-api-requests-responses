using exercise.wwwapi.Models;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IRepository<Book, int>
    {
        public Book Add(Book entity)
        {
            return BookCollection.AddBook(entity);
        }
        public List<Book> GetAll()
        {
            return BookCollection.GetBooks();
        }
        public Book GetOne(int id)
        {
            return BookCollection.GetABook(id);
        }
        public Book Update(int id, Book entity)
        {
            return BookCollection.UpdateBook(id, entity);
        }

        public Book Delete(int id)
        {
            return BookCollection.DeleteBook(id);
        }

    }
}
