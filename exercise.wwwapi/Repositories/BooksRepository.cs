using exercise.wwwapi.Data;
using exercise.wwwapi.Models;


namespace exercise.wwwapi.Repositories
{
    public class BooksRepository
    {
        private BookCollection _books;

        public BooksRepository(BookCollection books)
        {
            _books = books;
        }

        public Books CreateBook(string title, int numPages, string author, string genre)
        {
            return _books.Create(title, numPages, author, genre);
        }

        public Books RemoveBook(int id)
        {
            return _books.Remove(id);
        }

        public List<Books> getAllBooks()
        {
            return _books.getAll();
        }
    }
}
