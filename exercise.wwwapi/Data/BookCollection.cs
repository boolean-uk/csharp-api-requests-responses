using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> _books = new List<Book>() {
            new Book(1, "title1", 50, "author1", "genre1"), 
            new Book(2, "title2", 75, "author2", "genre3") 
        };

        public Book Add(Book book)
        {
            book.Id = _books.Max(x => x.Id)+1;

            _books.Add(book);

            return book;
        }

        public List<Book> GetAll()
        {
            return _books.ToList();
        }

        public void Delete(Book book)
        {
            _books.Remove(book);
        }
    }
}
