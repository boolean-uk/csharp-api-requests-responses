using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository
    {
        private BookCollection _Books;

        public BookRepository(BookCollection books)
        {
            _Books = books;
        }

        public List<Book> GetAllBooks()
        {
            return _Books.books;
        }
        public Book AddBook(string title, int numPages, string author, string genre)
        {
            return _Books.AddBook(title, numPages, author, genre); 
        }
        public Book? GetBook(int id)
        {
            return _Books.GetBook(id);
        }

        public Book? UpdateBook(int id, BookUpdatePayload updateData)
        {
            var book = _Books.GetBook(id);
            if(book == null)
            {
                return null;
            }
            bool hasUpdate = false;

            if(updateData.Title != null)
            {
                book.title = (string)updateData.Title;
                hasUpdate = true;
            }
            if(updateData.Author != null)
            {
                book.author = (string)updateData.Author;
                hasUpdate = true;
            }
            if (updateData.numPages != null)
            {
                book.numPages = (int)updateData.numPages;
                hasUpdate = true;
            }
            if(updateData.genre != null)
            {
                book.genre = (string)updateData.genre;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data");
            
            return book;

        }
        public Book? RemoveBook(int id)
        {
            return _Books.RemoveBook(id);
        }




    }
}
