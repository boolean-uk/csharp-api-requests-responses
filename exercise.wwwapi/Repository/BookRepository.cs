using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository: IBookRepository
    {
        private BookCollection _books;

        public BookRepository(BookCollection books)
        {
            _books = books;
        }

        public List<Book> GetBooks()
        {
            return _books.GetAll();
        }

        public Book AddBook(BookCreatePayload bookData)
        {
            return _books.AddBook(bookData);
        }
        public Book GetBook(int id)
        {
            return _books.GetBook(id);
        }

        public Book UpdateBook(int id, BookUpdatePayload updateData)
        {
            return _books.UpdateBook(id, updateData);
        }

        public Book DeleteBook(int id)
        {
            return _books.DeleteBook(id);
        }
    }
}
