using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Book? GetById(int id);
        public Book AddBook(BookPayload data);
        public Book UpdateBook(int id, BookUpdatePayload data);
        public Book DeleteBook(int id);
    }
}
