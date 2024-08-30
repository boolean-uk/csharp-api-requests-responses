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

        public List<Book> GetAllBooks()
        {
            return BookCollection.GetAllBooks();
        }

        public Book GetBook(int id)
        {
            return BookCollection.GetBook(id);
        }

        public Book UpdateBook(int id, Book book)
        {
            return BookCollection.UpdateBook(id, book);
        }

        public Book DeleteBook(int id)
        {
            return BookCollection.DeleteBook(id);
        }
    }
}
