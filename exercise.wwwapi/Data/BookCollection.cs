using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        public static int IdCount = 1;
        private static List<Book> books = new List<Book>();

        public static Book Add(Book book)
        {
            book.Id = IdCount;
            books.Add(book);
            IdCount++;
            return book;
        }

        public static List<Book> GetBooks()
        {
            return books;
        }

        public static Book Get(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public static Book Update(int id, Book book)
        {
            Book b = books.Find(b => b.Id == id);
            b.Title = book.Title;
            b.Author = book.Author;
            b.NumPages = book.NumPages;
            b.Genre = book.Genre;
            return b;
        }

        public static Book Delete(int id)
        {
            Book b = books.Find(b => b.Id == id);
            books.Remove(b);
            return b;
        }
    }
}
