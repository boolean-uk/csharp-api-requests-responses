using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IRepository<Book>
    {
        public Book Add(Book t)
        {
            return BookCollection.AddBook(t);
        }

        public Book Delete(string name)
        {
            return BookCollection.DeleteBook(name) ;
        }

        public Book Get(string name)
        {
            return BookCollection.GetBook(name);
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetAllBooks();
        }

        public Book Update(string name, Book t)
        {
            return BookCollection.UpdateBook(name, t);
        }
    }
}
