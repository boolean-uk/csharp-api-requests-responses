using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IBookData
    {
        private List<Book> _books = new List<Book>()
        {
            new Book("How To Write APIs: The Hard Truths", 401, "H.P. Lancraft", "Non-Fiction"),
            new Book("Parry Hotter and the Repository Chamber of Secrets", 501, "Haha J.K.", "Fantasy")
        };
        public Book Add(BookCreate book)
        {
            Book newBook = new Book(book.Title, book.NumPages, book.Author, book.Genre);
            _books.Add(newBook);
            return newBook;
        }

        public Book Delete(int id)
        {
            Book book = _books.FirstOrDefault(b => b.Id == id);
            _books.Remove(book);
            return book;
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book Update(int id, BookCreate book)
        {
            Book bookToUpdate = _books.FirstOrDefault(b => b.Id ==id);
            bookToUpdate.Author = book.Author;
            bookToUpdate.NumPages = book.NumPages;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Genre = book.Genre;
            return bookToUpdate;
        }
    }
}
