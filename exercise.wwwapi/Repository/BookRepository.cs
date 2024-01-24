using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Xml.Linq;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _books;
        public BookRepository(BookCollection books)
        {
            _books = books;
        }
        public List<Book> GetAllBooks()
        {
            return _books.GetAllBooks();
        }

        public Book AddBook(string title, int numPages, string author, string genre)
        {
            return _books.AddBook(title, numPages, author, genre);
        }

        public Book? GetBook(int id)
        {
            return _books.GetBook(id);
        }

        public Book? UpdateBook(int id, BookUpdatePayload updateData)
        {
            var book = _books.GetBook(id);
            if (book == null)
            {
                return null;
            }

            bool hasUpdate = false;

            if (updateData.title != null)
            {
                book.Title = updateData.title;
                hasUpdate = true;
            }
            if (updateData.numPages != null) 
            {
                book.NumPages = (int)updateData.numPages;
                hasUpdate = true;
            }
            if(updateData.author != null)
            {
                book.Author = updateData.author;
                hasUpdate = true;
            }
            if (updateData.genre != null)
            {
                book.Genre = updateData.genre;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");

            return book;
        }

        public Book? RemoveBook(int id)
        {
            Book book = _books.GetBook(id);
            if (book == null)
            {
                return null;
            }
            _books.RemoveBook(id);
            return book;
        }
    }
}
