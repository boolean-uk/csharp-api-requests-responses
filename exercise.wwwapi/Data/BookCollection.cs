using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private List<Book> _books = new List<Book>(){
           new Book(99999, "C# for beginners", 500, "Nigel", "Fiction"),
           // new Book("C#")
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
            var updatedBook = _books.Find(x => x.Id == id);
            updatedBook = book;

            return updatedBook;
        }

        public Book Delete(int id)
        {
            Book deletedBook = _books.Find(x => x.Id == id);
            _books.Remove(deletedBook);

            return deletedBook;
        }
    }
}
