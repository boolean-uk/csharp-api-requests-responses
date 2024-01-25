using exercise.wwwapi.Models.Book;
using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private int id = 0;
        private List<Book> books = new List<Book>();


        public Book AddBook(BookPayload payload)
        {
            var book = new Book(id++, payload);
            books.Add(book);
            return book;
        }

        public List<Book> GetAllBooks()
        {
            var listOfBooks = new List<Book>(books);
            if (listOfBooks.Count <= 0 || listOfBooks == null) { return null; }
            return listOfBooks;
        }

        public Book GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id.Equals(id));
            return book;
        }

        public Book UpdateBook(int id, BookPayload payload)
        {
            var book = GetBook(id);
            if (!string.IsNullOrWhiteSpace(payload.title)) { book.Title = payload.title; }
            if (!(payload.numPages <= 0)) { book.NumPages = payload.numPages; }
            if (!string.IsNullOrWhiteSpace(payload.author)) { book.Author = payload.author; }
            if (!string.IsNullOrWhiteSpace(payload.genre)) { book.Genre = payload.genre; }

            return book;

        }

        public Book RemoveBook(int id)
        {
            var book = GetBook(id);
            if (book == default) { return null; }
            books.Remove(book);
            return book;
        }
    }
}
