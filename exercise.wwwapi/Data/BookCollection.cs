using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _Books = new List<Book>();

        public static Book Add(Book Book)
        {
            _Books.Add(Book);

            return Book;
        }

        public static Book Delete(int Id)
        {
            Book Book = _Books.FirstOrDefault(x => x.Id == Id);
            if (Book != null) _Books.Remove(Book);
            return Book;
        }

        public static Book Get(int Id)
        {
            Book Book = _Books.FirstOrDefault(x => x.Id == Id);
            return Book;
        }

        public static Book Update(int Id, Book Book)
        {
            Book BookToUpdate = _Books.FirstOrDefault(y => y.Id == Id);
            BookToUpdate.Title = Book.Title;
            BookToUpdate.author = Book.author;
            BookToUpdate.genre = Book.genre;
            BookToUpdate.numpages = Book.numpages;
            return BookToUpdate;
        }

        public static List<Book> getAll()
        {
            return _Books.ToList();
        }
    }
}
