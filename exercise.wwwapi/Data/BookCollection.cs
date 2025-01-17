using System.Reflection;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() { Id = 1, title = "Harry Potter", numPages = 302, author = "JK.Rowling", genre = "fantasy"},
            new Book() { Id = 2, title = "Harry Potter2", numPages = 322, author = "JK.Rowling", genre = "fantasy"}
        };

        public static List<Book> GetBooks()
        {
            return _books;
        }

        public static Book AddBook(Book book)
        {
            int id = _books.Max(x => x.Id) + 1;
            book.Id = id;
            _books.Add(book);
            return book;
        }

        public static Book GetBookById(int id)
        {
            foreach (Book book in _books)
            {
                if (book.Id == id) return book;
            }
            return null;
        }

        public static Book UpdateBookById(int id, string title, int numpages, string author, string genre)
        {
            foreach (Book book in _books)
            {
                if (book.Id == id)
                {
                    book.title = title;
                    book.author = author;
                    book.genre = genre;
                    book.numPages = numpages;
                    return book;
                }
            }
            return null;
        }

        public static Book DeleteBook(int id)
        {
            Book deleted;
            foreach(Book book in _books)
            {

                if (book.Id == id)
                {
                    deleted = book;
                    _books.Remove(book);
                    return deleted;
                }
            }
            return null;
        }
    }
}
