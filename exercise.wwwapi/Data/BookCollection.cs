using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>();

        public static void Initialize()
        {
            _books.Add(new Book( "Nathan", "King", "Thriller", 786));
            _books.Add(new Book( "GameOfThrones", "Osama", "Fantasy", 785));
        }

        public static Book Get(int id)
        {
            return _books.FirstOrDefault(p => p.Id == id);
        }

        public static Book Add(Book entity)
        {
            _books.Add(entity);
            return entity;
        }

        public static bool Remove(int id)
        {
            return _books.RemoveAll(p => p.Id == id) > 0 ? true : false;
        }

        public static List<Book> Books { get { return _books; } }
    }
}
