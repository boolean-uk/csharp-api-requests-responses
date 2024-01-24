using exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Repository.BookRepositories
{
    public interface IBookRepository
    {
        public List<Book> getAllBooks();
        public Book getBookById(int _id);
        public Book AddBook(BookPostPayload payload);
        public Book UpdateBook(int _id, BookPutPayload payload);
        public void DeleteBook(int _id);
    }
}
