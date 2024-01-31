using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();

        public Book AddBook(string title, int numPages, string author, string genre);
    }
}
