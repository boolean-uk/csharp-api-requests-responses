using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> books = new List<Book>();

        public static Book Add(Book book)
        {
            books.Add(book);

            return book;
        }

        public static List<Book> getAll()
        {
            return books.ToList();
        }

        public static Book Get(Guid id)
        {
            return books.FirstOrDefault(x => x.id == id);
        }

        public static void Delete(Guid id)
        {
            Book book = books.FirstOrDefault(x => x.id == id);
            books.Remove(book);
        }
        public static Book Update(Book newBookvalues, Guid id)
        {
            Book book = books.FirstOrDefault(x => x.id == id);
            book.Title = newBookvalues.Title;
            book.Author = newBookvalues.Author;
            book.NumPages = newBookvalues.NumPages;
            book.Genre = newBookvalues.Genre;

            return book;
        }
    }
}
