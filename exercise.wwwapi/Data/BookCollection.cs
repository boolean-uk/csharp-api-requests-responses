using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        public static List<Book> _books = new List<Book>()
        {
            new Book() { Id=1, Title="Harry Potter and The Philosophers's stone", NumPages=500, Author="JK Rowling", Genre="Fantasy" },
            new Book() { Id=2, Title="Harry Potter and The Prizoner of Azkaban", NumPages=600, Author="JK Rowling", Genre="Fantasy" }
        };

      
        public static List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public static Book AddBook(Book entity)
        {
            if (_books.Any(b => b.Id == entity.Id)) return null; // already exists
            entity.Id = _books.Max(b => b.Id); // find max id in a collection + 1
            _books.Add(entity);
            return entity;
        }

        public static Book GetABook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public static Book UpdateBook(int id, Book entity)
        {
            var book = _books.Find(b => b.Id == id);
            book = entity;
            return book;
        }

        public static Book DeleteBook(int id)
        {
            var book = _books.Find(b => b.Id == id);
            _books.Remove(book);
            return book;
        }
    }
}
