using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private int _id = 1;
        private List<Book> _books = new List<Book>()
        {
            new Book(0, "A Game of Thrones", 780, "George R.R. Martin", "Fantasy")
        };
        public Book AddBook(string title, int numPages, string author, string genre)
        {
            Book book = new Book(_id ,title, numPages, author, genre);
            _id++;
            _books.Add(book);
            return book;
        }
        public List<Book> GetAllBooks() 
        {
            return _books.ToList();
        }
        public Book? GetBook(int id)
        {
            return _books.FirstOrDefault(t => t.Id == id);
        }
        public Book? RemoveBook(int id)
        {
           Book temp = GetBook(id);
           _books.Remove(temp);
            return temp;
        }
    }
}
