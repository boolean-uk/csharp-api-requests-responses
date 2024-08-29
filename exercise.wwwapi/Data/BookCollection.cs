using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() {Id= Guid.NewGuid(), Title="A Game Of Thrones", NumPages=780, Author="George R.R Martin", Genre="Fantasy"},
        };

        public static Book Add(Book book)
        {
            _books.Add(book);
            return book;
        }

        public static List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public static Book GetBook(Guid id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public static Book Update(Guid id, Book newValues)
        {
            Book book = _books.FirstOrDefault(x => x.Id == id);
  
            book.Title = newValues.Title;
            book.NumPages = newValues.NumPages;
            book.Author = newValues.Author;
            book.Genre = newValues.Genre;

            return book;
        }

        public static void Delete(Guid id)
        {
            Book book = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(book);
            Console.WriteLine("Book removed!");
        }
    }
}
