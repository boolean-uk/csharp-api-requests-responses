using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book AddBook(Book book)
        {
            BookCollection.AddBook(book);
            return book;
        }

        public Book DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book UpdateBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
