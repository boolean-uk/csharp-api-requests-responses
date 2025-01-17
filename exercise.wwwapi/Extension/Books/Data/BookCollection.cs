using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Extension.Books.Model;

namespace exercise.wwwapi.Extension.Books.Data
{
    public class BookCollection
    {
        private static List<Book> _books { get; set; } = new List<Book>();
        public static void Initialize()
        {
            _books.Add(new Book() { Id = 1, title = "1984", numPages = 328, author = "George Orwell", genre = "Dystopian" });
            _books.Add(new Book() { Id = 2, title = "To Kill a Mockingbird", numPages = 281, author = "Harper Lee", genre = "Classic Fiction" });
            _books.Add(new Book() { Id = 3, title = "The Great Gatsby", numPages = 180, author = "F. Scott Fitzgerald", genre = "Classic Fiction" });
            _books.Add(new Book() { Id = 4, title = "The Catcher in the Rye", numPages = 277, author = "J.D. Salinger", genre = "Coming-of-Age Fiction" });
            _books.Add(new Book() { Id = 5, title = "The Hobbit", numPages = 310, author = "J.R.R. Tolkien", genre = "Fantasy" });
        }

        public Book Add(Book book)
        {

            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);

            return book;
        }

        public List<Book> getAll()
        {
            return _books.ToList();
        }

        public bool Remove(int id)
        {
            return _books.RemoveAll(p => p.Id == id) > 0 ? true : false;
        }
    }

}
