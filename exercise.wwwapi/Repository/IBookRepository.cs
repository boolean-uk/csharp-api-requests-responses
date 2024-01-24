using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();

        public Book AddBook(string title, int numPages, string author, string genre);

        public Book? GetBook(int id);

        public Book? UpdateBook(Book book, BookUpdatePayload updateData);

        public List<Book> DeleteBook(int id);
    }
}
