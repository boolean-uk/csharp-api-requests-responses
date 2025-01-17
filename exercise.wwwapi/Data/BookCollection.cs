using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        public static List<Book> _books = new List<Book>()
        {
            new Book("A Song About Ice and Fire", 1234, "George R. Martin", "Fantasy"),
            new Book("LOTR", 432, "JRR Tolkien", "Documentary")
        };

        public static Book Add(Book book)
        {
            _books.Add(book);
            return book;
        }

        public static List<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public static Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public static Book Update(int id, Book book)
        {
            Book BookToUpdate = Get(id);
            BookToUpdate.title = book.title;
            BookToUpdate.author = book.author;
            BookToUpdate.genre = book.genre;
            BookToUpdate.numPages = book.numPages;
            return BookToUpdate;
        }

        public static Book Delete(int id)
        {
            Book bookToDelete = Get(id);
            _books.Remove(bookToDelete);
            return bookToDelete;
        }
    }
}
