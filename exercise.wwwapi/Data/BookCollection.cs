using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {

        private static List<Book> books = new List<Book>()
        {
            new Book("A Game of Thrones", 780, "George R.R Martin", "Fantasy"),
            new Book("A Dance with Dragons", 1000, "George R.R Martin", "Fantasy")
        };

        public static Book AddBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public static List<Book> GetAllBooks()
        {
            return books;
        }

        public static Book GetBook(int id) 
        {
            var match = books.FirstOrDefault(x => x.bookID == id);
            return match;
        }

        public static Book UpdateBook(int id, Book book) 
        {
            var match = books.FirstOrDefault(x => x.bookID == id);
            match.title = book.title;
            match.numPages = book.numPages;
            match.author = book.author;
            match.genre = book.genre;
            return match;
        }

        public static Book DeleteBook(int id) 
        {
            var match = books.FirstOrDefault(x => x.bookID == id);
            books.Remove(match);
            return match;
        }
    }
}
