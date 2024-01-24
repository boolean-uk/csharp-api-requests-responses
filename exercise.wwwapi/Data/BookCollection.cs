using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {

        private static List<Book> _books = new List<Book>()
        {
            new Book(1, "A Game Of Thrones", "George R. R. Martin", "Fantasy", 760),
            new Book(2, "To Kill a Mockingbird", "Harper Lee", "Fiction", 336),
            new Book(3, "The Great Gatsby", "F. Scott Fitzgerald", "Classics", 180),
            new Book(4, "1984", "George Orwell", "Dystopian", 328)
        };

        public Book Create(Book book)
        {
            _books.Add(book);

            return book;
        }

        public bool Delete(int id)
        {
            Book book = _books.Find(x => x.ID == id);

            return _books.Remove(book);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book Get(int id)
        {
            return _books.Find(x => x.ID == id);
        }

        public Book Update(int id, Book book)
        {
            Book bk = Get(id);
            if (bk == null || bk == default(Book))
                return bk;

            _books.Remove(bk);
            _books.Add(book);
            return book;
        }
    }
}
