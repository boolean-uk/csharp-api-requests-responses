using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        public static List<Book> Books = [];
        public static void Initialize ()
        {
            Books.Add (new Book { Id = 1, Author = "Cerim", Title = "Hell Difficulty Tutorial", Genre = "Fantasy", NumPages = 1870 });
            Books.Add (new Book { Id = 2, Author = "l-Ryn-l", Title = "Path to Transcendence", Genre = "Litrpg", NumPages = 1843 });
            Books.Add (new Book { Id = 3, Author = "Soussouni", Title = "I Will Touch the Skies", Genre = "Fanfiction / Urban Fantasy", NumPages = 8643 });
            Books.Add (new Book { Id = 4, Author = "JLMullins", Title = "Millennial Mage", Genre = "A Slice of Life, Progression Fantasy", NumPages = 2450 });
            Books.Add (new Book { Id = 5, Author = "Selkie", Title = "Beneath the Dragoneye Moons", Genre = "Fantasy", NumPages = 6300 });
        }
    };
}
