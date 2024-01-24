using exercise.wwwapi.Models;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _bookCollection = new BookCollection();
        public Book CreateBook(string title, string author, string genre, int numPage)
        {
            return _bookCollection.CreateBook(title, author, genre, numPage);
        }

        public Book DeleteBook(int id)
        {
            return _bookCollection.DeleteBook(id);
        }

        public Book GetBook(int id)
        {
            return _bookCollection.GetBook(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookCollection.GetBooks();
        }

        public Book UpdateBook(int id, string title, string author, string genre, int numPage)
        {
            return _bookCollection.UpdateBook(id, title, author, genre, numPage);
        }
    }
}
