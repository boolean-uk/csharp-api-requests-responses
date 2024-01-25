using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private IBookData _bookData;

        public BookRepository(IBookData bookData)
        {
            _bookData = bookData;
        }

        public List<Book> GetBooks()
        {
            return _bookData.GetBooks();
        }

        public Book GetBook(int id)
        {
            Book book = _bookData.GetBook(id);

            return book;
        }

        public Book AddBook(Book book)
        {
            return _bookData.AddBook(book);
        }

        public Book UpdateBook(int id, BookPut book)
        {
            var foundBook = _bookData.GetBook(id);
            if (foundBook == null)
            {
                return null;
            }
            foundBook.Title = book.Title;
            foundBook.NumPages = book.NumPages;
            foundBook.Author = book.Author;
            foundBook.Genre = book.Genre;
            return foundBook;
        }

        public Book DeleteBook(int id)
        {
            return _bookData.DeleteBook(id);
        }
    }
}
