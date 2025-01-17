using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        public static List<Book> _books { get; set; } = new List<Book>();

        public static void Initialize()
        {
            _books.Add(new Book { Id = 1, Title = "A Game of Thrones", numPages = 780, Author = "George R.R. Martin", Genre = "Fantasy" });
        }

        public static Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }
        public static Book Add(Book entity)
        {
            entity.Id = _books.Max(x => x.Id) + 1;
            _books.Add(entity);
            return entity;
        }
        public static bool Remove(int id)
        {
            _books.RemoveAll(x => x.Id == id);
            return true;
        }
        public static Book Update(int id, Book entity)
        {

            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                book.Id = id;
                book.Author = entity.Author;
                book.Genre = entity.Genre;
                book.numPages = entity.numPages;
                book.Title = entity.Title;
            }
            return book;
        }


        public static List<Book> Books { get { return _books; } }
    }
}
