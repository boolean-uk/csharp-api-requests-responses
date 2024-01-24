
using exercise.wwwapi.Models.Payload;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository {

    public interface IBookRepository {

        public List<Book> GetAllBooks();
        public Book AddBook(string title, int numPages, string author, string genre);

        public Book? GetBook(string title);

        public Book? DeleteBook(string title);
        public Book? UpdateBook(string title, BookUpdatePayload updateData);
    }
}