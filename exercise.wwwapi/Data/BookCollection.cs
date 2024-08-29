using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private List<Book> _books = new List<Book>(){
           new Book(99999, "C# for beginners", 500, "Nigel", "Computer Science"),
           new Book(10000, "Java for beginners", 780, "Dave", "Horror"),
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
            var book = _books.Find(x => x.Id == id);

            return book;
        }

        public Book Update(int id, Book book)
        {
            int index = _books.FindIndex(x => x.Id == id);

            if (index == -1)
                return null;

            _books[index] = book;

            return book;
        }

        public Book Delete(int id)
        {
            Book deletedBook = _books.Find(x => x.Id == id);
            _books.Remove(deletedBook);

            return deletedBook;
        }
    }
}
