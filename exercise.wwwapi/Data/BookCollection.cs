using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() {Id = 1, Title = "A Game Of Thrones", Author = "George R. R. Martin", Genre = "Fantasy", NumPages = 760},
            new Book() {Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", NumPages = 336},
            new Book() {Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classics", NumPages = 180},
            new Book() {Id = 4, Title = "1984", Author = "George Orwell", Genre = "Dystopian", NumPages = 328}
        };

        public Book Add(Book book)
        {
            int Id = _books.Max(x => x.Id) + 1;
            book.Id = Id;
            _books.Add(book);
            return book;
        }

        public Book CreateBook(string title, string author, string genre, int numPage) 
        {
            int Id = _books.Max(x => x.Id) + 1;
            Book book = new Book() { Id = Id, Title = title, Author = author, Genre = genre, NumPages = numPage};
            Add(book);
            return book;
        }

        public List<Book> GetBooks() 
        {
            return _books.ToList();
        }

        public Book GetBook(int id)
        {
            return _books.Find(x => x.Id == id); ;
        }

        public Book UpdateBook(int id, string title, string author, string genre, int numPage)
        {
            Book tempBook = GetBook(id);
            tempBook.Title = title;
            tempBook.Author = author;
            tempBook.Genre = genre;
            tempBook.NumPages = numPage;
            return tempBook;
        }

        public Book DeleteBook(int id)
        {
            Book book = GetBook(id);
            _books.Remove(book);
            return book;
        }
    }
}
