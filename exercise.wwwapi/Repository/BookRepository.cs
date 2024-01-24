using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection books;

        public BookRepository(BookCollection books)
        {
            this.books = books;
        }

        public List<Book> GetAllBooks()
        {
            return books.GetAll();
        }

        public Book AddBook(string title, int numPages, string author, string genre)
        {
            return books.Add(title, numPages, author, genre);
        }

        public Book? GetBook(int id)
        {
            return books.Get(id);
        }

        public Book? UpdateBook(Book book, BookUpdatePayload updateData)
        {
            bool hasUpdate = false;

            if (updateData.title != null)
            {
                book.Title = (string)updateData.title;
                hasUpdate = true;
            }

            if (updateData.author != null)
            {
                book.Author = (string)updateData.author;
                hasUpdate = true;
            }

            if (updateData.numPages != null)
            {
                book.NumPages = (int)updateData.numPages;
                hasUpdate = true;
            }

            if (updateData.genre != null)
            {
                book.Genre = (string)updateData.genre;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");
            return book;
        }

        public List<Book> DeleteBook(int id)
        {
            books.Delete(id);
            return books.GetAll();
        }
    }
}
