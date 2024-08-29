using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() { Id=1,Title="A Game of Throens", NumPages = 780, Author = "George R.R. Martin", Genre = "Fantasy" },
        };
        public static Book AddBook(Book t)
        {
            _books.Add(t);
            return t;
        }

        public static Book DeleteBook(string name)
        {
            Book book = _books.FirstOrDefault(x => x.Id == Int32.Parse(name));
            _books.Remove(book);
            return book;
        }

        public static List<Book> GetAllBooks()
        {
            return _books;
        }

        public static Book GetBook(string name)
        {
            return _books.FirstOrDefault(x => x.Id == Int32.Parse(name));
        }

        public static Book UpdateBook(string name, Book t)
        {
            Book book = GetBook(name);
            var index = _books.FindIndex(x => x.Id == Int32.Parse(name));
            _books[index] = t;

            return book;
        }
    }
}
