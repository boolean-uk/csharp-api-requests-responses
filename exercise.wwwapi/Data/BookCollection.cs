using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {

        private List<Book> _books = new List<Book>()
        {
            new Book() { title = "A Game of Thrones", numPages = 780, author = "George R.R. Martin", genre = "Fantasy", id = 1},
            new Book() { title = "A Game of D", numPages = 7180, author = "DEW", genre = "Fantasy", id = 2}
        };

        public Book Add(Book book)
        {
            book.id = _books.Max(x => x.id) +1 ;        // Add Id + 1
            _books.Add(book);

            return book;
        }

        public List<Book> getAll()
        {
            return _books.ToList();
        }

        public Book Remove(Book book)
        {
            _books.Remove(book);
            return book;
        }

    }
}
