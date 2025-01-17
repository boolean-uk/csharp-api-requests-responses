using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IBook
    {
        public Book CreateBook(Book book)
        {
            return BookCollection.Add(book);
        }

        public Book DeleteBook(int id)
        {
            return BookCollection.Delete(id);
        }

        public Book GetBook(int id)
        {
            return BookCollection.Get(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return BookCollection.GetAllBooks();
        }

        public Book UpdateBook(int id, Book book)
        {
            return BookCollection.Update(id, book);
        }
    }
}
