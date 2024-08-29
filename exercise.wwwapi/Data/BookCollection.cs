using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>() 
        { 
            new Book () { Id = 1, Title = "A Game of Thrones", NumPages = 780, Author = "George R.R. Martin", Genre = "Fantasy"},
            new Book () { Id = 2, Title = "Harry Potter", NumPages = 500, Author = "J.K. Rowling", Genre = "Fantasy"}

        };

        public static Book CreateABook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public static List<Book> GetAllBooks() { return _books; }

        public static Book GetABook(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public static Book UpdateBook(int id, string newTitle, int newNumPages, string newAuthor, string newGenre)
        {
            Book updatedBook = _books.FirstOrDefault(x => x.Id == id);
            updatedBook.Title = newTitle;
            updatedBook.NumPages = newNumPages;
            updatedBook.Author = newAuthor;
            updatedBook.Genre = newGenre;

            return updatedBook;

        }

        public static Book DeleteBook(int id)
        {
            Book deleteLanguage = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(deleteLanguage);

            return deleteLanguage;
        }

    }
}
