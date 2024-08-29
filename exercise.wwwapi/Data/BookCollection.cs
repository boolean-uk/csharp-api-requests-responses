using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> books = new List<Book>()
        {
            //new Book() {title="A Game of Thrones", numPages=780, author="George R.R Martin", genre="Fantasy" }
        };

        public static Book AddBook(Book book)
        {
            books.Add(book);
            return book;
        }
    }
}
