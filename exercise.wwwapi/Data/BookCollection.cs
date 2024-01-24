using exercise.wwwapi.Models;
using System.Threading.Tasks;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> Books { get; set; }
        private int _id = 0;

        public BookCollection()
        {
            Books = new List<Book>();
            AddBook("The Idiot", 592, "Fyodor Dostoyevski", "Psychological realism");
            AddBook("The Overcoat", 52, "Nikolai Gogol", "Satire");
        }

        public Book AddBook(string title, int pageNum, string author, string genre)
        {
            _id++;
            var newBook = new Book(_id, title, pageNum, author, genre);
            Books.Add(newBook);

            return newBook;
        }

        public List<Book> GetAllBooks()
        {
            return Books.ToList();
        }

        public Book? GetBook(int id)
        {
            return Books.Find(b => b.Id == id);
        }

        public Book? DeleteBook(int id)
        {
            Book b = Books.Find(b => b.Id == id);
            Books.Remove(b);
            return b;
        }

    };


}
