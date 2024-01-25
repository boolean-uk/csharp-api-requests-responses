using exercise.wwwapi.Data;
using exercise.wwwapi.Models.Book;
using exercise.wwwapi.Models.Language;
using exercise.wwwapi.Repository.Interfaces;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepo
    {
        private BookCollection _books;

        public BookRepository(BookCollection books)
        {
            _books = books;
        }

        public Book Add(BookPayload payload)
        {
            return _books.AddBook(payload);
        }

        public Book Get(int id)
        {
            return _books.GetBook(id);
        }

        public List<Book> GetAll()
        {
            return _books.GetAllBooks();
        }

        public Book Remove(int id)
        {
            return _books.RemoveBook(id);
        }

        public Book Update(int id, BookPayload payload)
        {
            return _books.UpdateBook(id, payload);
        }
    }
}
