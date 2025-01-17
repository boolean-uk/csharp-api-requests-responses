using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {

        private static int uniqueBookIdCounter = 0;
        private static int getUniqueBookId()
        {
            return ++uniqueBookIdCounter;
        }
        private static List<Book> _books = new List<Book>(){
            new Book{
                bookId = getUniqueBookId(),
                title = "Dogs adventure in dogland",
                author = "K9",
                genre = "Action",
                numPages = 42,
                },
            new Book{
                bookId = getUniqueBookId(),
                title = "Cat tales",
                author = "FEl9",
                genre = "Comedy",
                numPages = 321,
                },
        };

        public static Book Add(Book book)
        {
            book.bookId = getUniqueBookId();
            BookCollection._books.Add(book);

            return book;
        }

        public static Book? Remove(string title)
        {
            Book? book = BookCollection._books.ToList().Where(x => x.title == title).FirstOrDefault();

            if (book != null)
                BookCollection._books.Remove(book);

            return book;
        }

        public static List<Book> getAll()
        {
            return BookCollection._books.ToList();
        }


        public static bool GetBook(string title, out List<Book> book)
        {
            // Books might have identical firsttitles...
            book = BookCollection._books.Where(x => x.title == title).ToList();
            if (book.Count == 0)
                return false;
            return true;
        }
    }
}
