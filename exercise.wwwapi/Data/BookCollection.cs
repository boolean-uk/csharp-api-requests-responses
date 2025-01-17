using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() { Id=1, Title="Moby-Dick", NumPages=720, Author="Herman Melville", Genre="Classics"},
            new Book() { Id=2, Title="Mistborn", NumPages=541, Author="Brandon Sanderson", Genre="Fantasy"}
        };

        public static Book Add(BookPost book)
        {
            var nextId = _books.Max(p => p.Id) + 1;
            Book newBook = new Book()
            {
                Id = nextId,
                Title = book.Title,
                NumPages = book.NumPages,
                Author = book.Author,
                Genre = book.Genre
            };

            _books.Add(newBook);
            return newBook;
        }

        public static List<Book> GetAll()
        {
            return _books.ToList();
        }

        public static Book GetOne(int id)
        {
            Book book = _books.FirstOrDefault(s => s.Id == id);
            return book;
        }
        public static Book Remove(int id)
        {
            Book book = _books.FirstOrDefault(s => s.Id == id);
            _books.Remove(book);
            return book;
        }

        public static Book Update(int id, BookPost update)
        {
            Book book = _books.FirstOrDefault(s => s.Id == id);
            book.Title = update.Title;
            book.Author = update.Author;
            book.Genre = update.Genre;
            book.NumPages = update.NumPages;
            return book;
        }
    };
}
