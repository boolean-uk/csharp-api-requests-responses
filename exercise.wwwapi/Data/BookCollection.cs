using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> _books = new List<Book>();
        static int counter = 1;

        public static Book Add(BookView bookView)
        {
            var book = new Book() { Id = counter, Title = bookView.Title, NumPages = bookView.NumPages, Author = bookView.Author, Genre = bookView.Genre };
            _books.Add(book);
            counter++;

            return book;
        }

        public static Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public static List<Book> GetAll()
        {
            return _books.ToList();
        }

        public static Book Delete(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book == null) return null;
            _books.Remove(book);
            foreach (Book b in _books)
            {
                if (b.Id > id) b.Id--;
            }
            counter--;
            return book;
        }

        public static Book Update(int id, BookView bookView)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            book.Title = bookView.Title;
            book.NumPages = bookView.NumPages;
            book.Author = bookView.Author;
            book.Genre = bookView.Genre;
            return book;
        }
    };
}
