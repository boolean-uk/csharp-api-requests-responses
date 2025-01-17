using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>(){
            new Book("1984", 328, "George Orwell", "Dystopian"),
            new Book("To Kill a Mockingbird", 281, "Harper Lee", "Fiction"),
            new Book("The Great Gatsby", 180, "F. Scott Fitzgerald", "Classic"),
            new Book("Moby Dick", 635, "Herman Melville", "Adventure"),
            new Book("Pride and Prejudice", 279, "Jane Austen", "Romance")
        };

        public static List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public static Book GetBook(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public static Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }
        public static Book UpdateBook(Book book, int id)
        {
            Book bookToUpdate = _books.Find(x => x.Id == id);
            bookToUpdate.Title = book.Title;
            bookToUpdate.NumPages = book.NumPages;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Genre = book.Genre;
            return bookToUpdate;
        }

        public static Book DeleteBook(int id)
        {
            var bookToRemove = _books.Find(x => x.Id == id);
            _books.Remove(bookToRemove);

            return bookToRemove;
        }

    }
}
