using exercise.wwwapi.Models;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public class BookRepository: IBookRepository
    {
        private BookCollection bookCollection;

        public BookRepository(BookCollection bookCollection)
        {
            this.bookCollection = bookCollection;
        }

        // Method to get all books
        public List<Book> GetAllBooks()
        {
            return bookCollection.Books;
        }

        // Method to get a book by id
        public Book? GetBook(int id)
        {
            return bookCollection.Books.FirstOrDefault(b => b.Id == id);
        }

        // Method to add a book
        // Return the book
        public Book AddBook(string title, int numPage, string author, string genre)
        {
            return bookCollection.AddBook(title, numPage, author, genre);
        }

        // Method to delete a book
        // If the book is not found, return null
        // If the book is found, delete the book and return the book
        public Book? DeleteBook(int id)
        {
            var book = bookCollection.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            bookCollection.Books.Remove(book);

            return book;
        }

        // Method to update a book
        // If the book is not found, return null
        // If the book is found, update the book and return the book
        public Book? UpdateBook(int id, BookUpdatePayload bookUpdatePayload)
        {
            var book = bookCollection.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            if (bookUpdatePayload.Title != null)
            {
                book.Title = bookUpdatePayload.Title;
            }

            if (bookUpdatePayload.NumPage != null)
            {
                book.NumPage = (int)bookUpdatePayload.NumPage;
            }

            if (bookUpdatePayload.Author != null)
            {
                book.Author = bookUpdatePayload.Author;
            }

            if (bookUpdatePayload.Genre != null)
            {
                book.Genre = bookUpdatePayload.Genre;
            }

            return book;
        }


    }
}