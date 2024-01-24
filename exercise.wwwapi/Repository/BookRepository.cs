using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        BookCollection _books;
        public BookRepository(BookCollection collection) 
        {
            _books = collection;
        }
        public Book AddBook(BookPayload data)
        {
            return _books.Add(data);
        }

        public Book DeleteBook(int id)
        {
            return _books.Delete(id);
        }

        public List<Book> GetAllBooks()
        {
            return _books.GetBooks();
        }

        public Book? GetById(int id)
        {
            return _books.GetBookByID(id);
        }

        public Book UpdateBook(int id, BookUpdatePayload data)
        {
            return _books.Update(id, data);
        }
    }
}
