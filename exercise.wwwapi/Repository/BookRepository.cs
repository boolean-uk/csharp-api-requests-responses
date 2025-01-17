using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book AddBook(Book book)
        {
            return BookCollection.AddBook(book);
        }

        public Book DeleteBook(int id)
        {
            return BookCollection.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return BookCollection.GetBooks();
        }

        public Book GetBook(int id)
        {
            return BookCollection.GetBookById(id);
        }

        public Book UpdateBook(int id, string title, int numpages, string author, string genre)
        {
            return BookCollection.UpdateBookById(id, title, numpages, author, genre);
        }
    }
}
