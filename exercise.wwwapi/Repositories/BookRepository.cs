using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks()
        {
            return BookCollection.GetBooks();
        }

        public Book GetABook(int id)
        {
            return BookCollection.GetABook(id);
        }

        public Book AddBook(Book book)
        {
            BookCollection.AddBook(book);
            return book;
        }

        public Book RemoveBook(Book book)
        {
            BookCollection.RemoveBook(book);
            return book;
        }

        public int IncreaseId()
        {
            return BookCollection.IncreaseId();
        }

        public Book UpdateBook(int id, string title, int numPages, string author, string genre)
        {
            Book updatetBook = BookCollection.UpdateBook(id, title, numPages, author, genre);
            return updatetBook;
        }
    }
}
