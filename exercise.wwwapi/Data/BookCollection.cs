using exercise.wwwapi.Models;
using static exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() {id = 1, title = "A Game Of Thrones", author = "George R. R. Martin", genre = "Fantasy", numPages = 760},
            new Book() {id = 2, title = "Harry Potter and the Philosopher's Stone", author = "J. K. Rowling", genre = "Fantasy", numPages = 223},
            new Book() {id = 3, title = "The Lion, the Witch and the Wardrobe", author = "C. S. Lewis", genre = "Fantasy", numPages = 172},
        
        };

        public List<Book> GetBooks()
        {
            return _books;
        }

        public Book AddBook(MakeBook book)
        {
            Book newBook = new Book() { id = _books.Max(x => x.id) + 1, author = book.author, genre = book.genre, numPages = book.numPages, title = book.title };
            _books.Add(newBook);
            return newBook;
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.id == id);
        }
        public Book UpdateBook(int id , MakeBook makeBook)
        {
            var existingBook = GetBook(id);

            if (existingBook == null)
            {
                return null;
            }
            existingBook.title = !string.IsNullOrEmpty(makeBook.title) ? makeBook.title : existingBook.title;
            existingBook.author = !string.IsNullOrEmpty(makeBook.author) ? makeBook.author : existingBook.author;
            existingBook.numPages = makeBook.numPages < 0 ? makeBook.numPages : existingBook.numPages;
            existingBook.genre = !string.IsNullOrEmpty(makeBook.genre) ? makeBook.genre : existingBook.genre;

            int index = _books.IndexOf(existingBook);
            _books[index] = existingBook;
            return existingBook;
        }
        public Book DeleteBook(int id)
        {
            var item = GetBook(id);
            if (item != null) { _books.Remove(item); return item; }

            return null;
        }

    }
}
