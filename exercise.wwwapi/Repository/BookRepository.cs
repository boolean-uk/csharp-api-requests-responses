using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository
    {
        public Book Create(Book entity)
        {
            return BookCollection.CreateBook(entity);
        }

        public Book Delete(int id)
        {
            return BookCollection.DeleteBook(id);
        }

        public Book Get(int id)
        {
            return BookCollection.getBook(id);
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetBooks();
        }

        public Book Update(int id, Book entity)
        {
            return BookCollection.UpdateBook(id, entity);
        }
    }
}
