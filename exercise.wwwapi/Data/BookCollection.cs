using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        public List<Book> books;
        private int _id = 0;

        public BookCollection() 
        {
            books = new List<Book>();
            AddBook("A Game of Thrones", 780, "George R.R. Martin", "Fantasy");
            AddBook("The House", 222, "Bill Smith", "Fiction");

        }

        public Book AddBook(string title, int numPages, string author, string genre)
        {
            _id++;
            Book newBook = new Book(_id, title, numPages, author, genre);
            books.Add(newBook);
            return newBook;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.FirstOrDefault(b => b.id == id);
        }
        public Book RemoveBook(int id)
        {
            var book = books.FirstOrDefault(b => b.id == id);

            books.Remove(book);
            return book;

        }
    }
}
