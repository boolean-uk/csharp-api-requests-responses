using exercise.wwwapi.Models;

namespace exercise.wwwapi
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        public Book GetABook(int id);
        public Book AddBook(Book book);
        public Book RemoveBook(Book book);
        public Book UpdateBook(int id, string title, int numPages, string author, string genre);

        public int IncreaseId();

    }
}
