using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> Books = new List<Book>()
        {
            new("A game of Thrones", 780, "George R. R. Martin", "Fantasy"),
            new("The Hobbit", 310, "J.R.R. Tolkien", "Fantasy"),
        };

        public List<Book> GetAll()
        {
            return Books;
        }
        public Book AddBook(BookCreatePayload bookData)
        {
            var newBook = new Book(bookData.Title, bookData.NumPages, bookData.Author, bookData.Genre);
            Books.Add(newBook);
            return newBook;
        }

        public Book GetBook(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public Book UpdateBook(int id, BookUpdatePayload bookData)
        {
            var book = GetBook(id);
            if (book == null)
            {
                return null;
            }
            book.Title = bookData.Title ?? book.Title;
            book.NumPages = bookData.NumPages ?? book.NumPages;
            book.Author = bookData.Author ?? book.Author;
            book.Genre = bookData.Genre ?? book.Genre;
            return book;
        }

        public Book DeleteBook(int id)
        {
            var book = GetBook(id);
            return Books.Remove(book) ? book : null;
        }


    }
}
