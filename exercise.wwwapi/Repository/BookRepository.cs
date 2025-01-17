using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBook
    {
        public Book AddBook(Book book)
        {
            return BookCollection.AddBook(book);
        }

        public Book DeleteBook(int id)
        {
            return BookCollection.DeleteBook(id);
        }

        public Book GetBook(int id)
        {
            return BookCollection.GetBook(id);
        }

        public List<Book> GetBooks()
        {
            return BookCollection.GetBooks();
        }

        public Book UpdateBook(Book book, int id)
        {
            return BookCollection.UpdateBook(book, id);
        }
    }
}
