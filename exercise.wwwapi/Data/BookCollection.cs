using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book() { id = 1, title ="The Final Empire", numPages = 421, author="Brandon Sanderson", genre = "Fantasy" },
            new Book() {id = 2,  title = "The Return of The King", numPages= 501, author= "JRR Tolkien", genre = "Fantasy" }
        };

        public static List<Book> getAll()
        {
            return _books.ToList();
        }

        public static Book getOne(string idString)
        {
            int id = int.Parse(idString);
            return _books.FirstOrDefault(x => x.id == id);
        }
        public static Book Add(Book book)
        {
            int newId = _books.Max(x => x.id) + 1;
            book.id = newId;

            _books.Add(book);

            return book;
        }

        public static Book Update(string idString, Book book)
        {
            int id = int.Parse(idString);
            Book toReplace = _books.FirstOrDefault(x => x.id == id);
            book.id = id;
            _books[_books.IndexOf(toReplace)] = book;

            return book;
        }

        public static Book Delete(string idString)
        {
            int id = int.Parse(idString);
            Book toDelete = _books.FirstOrDefault(x => x.id == id);
            _books.Remove(toDelete);

            return toDelete;
        }
    }
}
