using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book(1, "Hunger Games", 273, "diet", "Someone famous"),
            new Book(2, "Ready Player One", 340, "dystopian", "Someone famous, but not that famous")
        };

        internal static Book Add(Book book)
        {
            if (_books.Find(x => x.Title == book.Title) == null)
            {
                _books.Add(new Book(_books.Max(x => x.Id) + 1, book.Title, book.numPages, book.Genre, book.Author));
                return _books.Find(x=>x.Title == book.Title);
            }
            return null;
        }

        internal static Book DeleteBook(int id)
        {
            Book book = null;
            if (_books.Remove(book = _books.FirstOrDefault(x=>x.Id==id)))
            {
                return book;
            }
            return null;
        }

        internal static List<Book> GetAll() { return _books; }

        internal static Book GetBook(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        internal static Book UpdateBook(int id, Book book)
        {
            if (_books.Find(x => x.Id == id) != null)
            {
                Book bookHere = _books.Find(x => x.Id == id);
                bookHere.Title = book.Title;
                bookHere.Author = book.Author;
                bookHere.Genre = book.Genre;
                bookHere.numPages = book.numPages;
                return bookHere;
            }

            return null;
        }
    }
}
