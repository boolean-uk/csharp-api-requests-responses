using exercise.wwwapi.Models;
using System.Reflection.Metadata.Ecma335;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {

            new Book() { Id = 1, Title = "A Game of Thrones", numPages = 780, Author = "George R.R Martin", Genre = "Fantasy" },
            new Book() { Id= 2, Title="The holy quran", numPages=10000, Author="Allah", Genre="Religion"}

        };
        public static List<Book> Books { get { return _books; } }

        public static List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public static Book CreateBook(Book book) //taking inspiration from your joke method.
        {
            if (_books.Any(x => x.Title == book.Title)) return null;

            book.Id = _books.Max(x => x.Id) + 1; //find maximum id and + 1.

            _books.Add(book);

            return book;

        }
        public static Book getBook(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);

            return book;
        }
        public static Book UpdateBook(int id, Book book)
        {
            int index = _books.FindIndex(book => book.Id == id);

            _books[index] = book;

            return book;
        }
        public static Book DeleteBook(int id)
        {
            var deletedBook = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(deletedBook);
            return deletedBook;
        }


    }
}
