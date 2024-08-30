using exercise.wwwapi.Models;
namespace exercise.wwwapi.Data
{
    public static class BooksCollection
    {
        private static List<Book> books = new List<Book>
        {
            new Book("A Game of Thrones", 780, "George R.R. Martin", "Fantasy") ,
            new Book("1984", 600, "George Orwell", "Fantasy")
        };

        public static List<Book> Books { get { return books; } }

        public static Book AddBook(Book B)
        {
            books.Add(B);
            return B;
        }

        public static Book RemoveBook(Book B)
        {
            books.Remove(B);
            return B;
        }


    }
}
