using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> _books = new List<Book>(){
            new Book(1) {Title = "A Game of Thrones", NumPages = 780, Author = "George R.R. Martin", Genre = "Fantasy"},
            new Book(2) {Title = "Reading for dummies", NumPages = 200, Author = "John Human", Genre = "Self-Help"},
            
        };

        public Book Add(Book book)
        {
            _books.Add(book);

            return book;
        }

        public List<Book> getAll()
        {
            return _books.ToList();
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public Book Update(int id, Book book)
        {
            Book b = _books.FirstOrDefault(x => x.Id == id);
            b.Author = book.Author;
            b.Genre = book.Genre;
            b.NumPages = book.NumPages;
            b.Title = book.Title;
            return b;
        }

        public void Delete(int id)
        {
            _books.Remove(_books.FirstOrDefault(x => x.Id == id));
        }
    }
}
