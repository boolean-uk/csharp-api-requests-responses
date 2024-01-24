using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BooksCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() {Id = 1, Title = "A Game Of Thrones", Author = "George R. R. Martin", Genre = "Fantasy", numPages = 760},
            new Book() {Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", numPages = 336},
            new Book() {Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classics", numPages = 180},
            new Book() {Id = 4, Title = "1984", Author = "George Orwell", Genre = "Dystopian", numPages = 328}
        };

        public Book CreateBook(BookPut bookPut)
        {
            Book book = new Book() { 
                Id = _books.Select(x => x.Id).Max() + 1,
                Title = bookPut.Title,
                Author = bookPut.Author,
                Genre = bookPut.Genre,
                numPages = bookPut.numPages
            };
            _books.Add(book);
            return book;
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int Id)
        {
            return _books.FirstOrDefault(x => x.Id == Id);
        }

        public Book UpdateBook(int Id, BookPut newBook)
        {
            Book book = GetBookById(Id);
            book.Update(newBook);
            return book;
        }

        public Book DeleteBook(int Id)
        {
            Book book = GetBookById(Id);
            _books.Remove(book);
            return book;
        }
    }
}
