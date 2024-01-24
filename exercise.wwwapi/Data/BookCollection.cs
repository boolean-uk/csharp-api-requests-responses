using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        public List<Book> Books { get; set; }
        private int _id = 0; // Id for books

        public BookCollection()
        {
            Books = new List<Book>();
            AddBook("The Lord of the Rings", 1000, "J.R.R. Tolkien", "Fantasy");
            AddBook("The Hobbit", 300, "J.R.R. Tolkien", "Fantasy");
            AddBook("The Silmarillion", 500, "J.R.R. Tolkien", "Fantasy");
        }

        public Book AddBook(string title, int numPage, string author, string genre)
        {
            _id++;
            var book = new Book(_id ,title, numPage, author, genre);
            Books.Add(book);
            return book;
        }


        public Book? GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }
    };
}