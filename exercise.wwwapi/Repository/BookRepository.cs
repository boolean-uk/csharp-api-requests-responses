using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

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

        public Book AddBook(string title, int pageCount, string author, string genre)
        {
            return _books.AddBook(title, pageCount, author, genre);
        }

        public Book? GetBook(int id) 
        {
            Book b = _books.GetBook(id);

            if (b == null) 
            {
                throw new Exception("Book not found!");
            }
            return b;
        }

        public Book? DeleteBook(int id)
        {
            Book b = _books.DeleteBook(id);

            if (b == null)
            {
                throw new Exception("Book not found!");
            }

            
            return b;
        }

        public Book? UpdateBook(int id, BookUpdatePayload updateData)
        {
            var book = _books.GetBook(id);

            if(book == null) 
            {
                return null;
            }

            bool hasTitle = false;
            bool hasPages = false;
            bool hasAuthor = false;
            bool hasGenre = false;

            if (updateData.title.Length > 0) 
            {
                book.Title = (string)updateData.title;
                hasTitle = true;
            }

            if(updateData.numPages > 0) 
            {
                book.NumPages = (int)updateData.numPages;
                hasPages = true;
            }

            if (updateData.author.Length > 0)
            {
                book.Author = (string)updateData.author;
                hasAuthor = true;
            }

            if (updateData.genre.Length > 0)
            {
                book.Genre = (string)updateData.genre;
                hasGenre= true;
            }

            if (!hasTitle || !hasPages || !hasAuthor || !hasGenre)
            {
                throw new Exception("Update needs all the fields provided!");
            }

            return book;
        }
    }
}
