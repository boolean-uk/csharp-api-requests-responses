using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IBookData
    {
        private List<Book> _books = new List<Book>()
        {
            new Book() {Id = 1, Title = "A Game Of Thrones", Author = "George R. R. Martin", Genre = "Fantasy", NumPages = 760},
            new Book() {Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", NumPages = 336},
            new Book() {Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classics", NumPages = 180},
            new Book() {Id = 4, Title = "1984", Author = "George Orwell", Genre = "Dystopian", NumPages = 328}
        };

        public IEnumerable<Book> GetBooks()
        {
            return _books.ToList();
        }

        public Book AddBook(Book book)
        {
            book.Id = _books.Max(x => x.Id) + 1;
            _books.Add(book);
            return book;
        }
        public Book UpdateBook(int id, BookPut book)
        {
            var target = _books.FirstOrDefault(book => book.Id == id);
            target.Title = book.Title;
            target.Author = book.Author;
            target.Genre = book.Genre;
            target.NumPages = book.NumPages;
            return target;
        }
        public Book DeleteBook(int id, out Book book)
        {
            book = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(book);
            return book;
        }

        public bool GetBook(int id, out Book book)
        {
            book = _books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return false;
            }
            return true;
        }
    };


}
