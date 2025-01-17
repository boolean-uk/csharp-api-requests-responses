
namespace exercise.wwwapi
{
    public class BookCollection
    {
        private List<Book> _books = new List<Book>()
        {
            new Book() { Id = 1, Title = "A Game of Thrones", NumPages = 780, Author = "George R.R. Martin", Genre = "Fantasy" },
            new Book() { Id = 2, Title = "The Hobbit", NumPages = 310, Author = "J.R.R. Tolkien", Genre = "Fantasy" }
        };

        public Book Add(Book book)
        {
            _books.Add(book);
            return book;
        }

        public List<Book> GetAll()
        {
            return _books.ToList();
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public Book Update(int id, string newTitle, int newNumPages, string newAuthor, string newGenre)
        {
            Book book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                book.Title = newTitle;
                book.NumPages = newNumPages;
                book.Author = newAuthor;
                book.Genre = newGenre;
                return book;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var bookToRemove = _books.FirstOrDefault(x => x.Id == id);
            if (bookToRemove != null)
            {
                return _books.Remove(bookToRemove);
            }
            return false;
        }
    }
}
