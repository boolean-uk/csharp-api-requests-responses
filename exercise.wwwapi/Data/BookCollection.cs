using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book(){Title = "The Hobbit", Author = "J.R.R. Tolkien", NumberOfPages = 310, Genre = "Fantasy", Id = 1},
            new Book(){Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", NumberOfPages = 180, Genre = "Fiction", Id = 2},
            new Book(){Title = "The Catcher in the Rye", Author = "J.D. Salinger", NumberOfPages = 230, Genre = "Fiction", Id = 3},
            new Book(){Title = "To Kill a Mockingbird", Author = "Harper Lee", NumberOfPages = 280, Genre = "Fiction", Id = 4},
            new Book(){Title = "1984", Author = "George Orwell", NumberOfPages = 328, Genre = "Dystopian", Id = 5},
        };

        public static Book Add(Book book)
        {
            book.Id = _books.Max(x => x.Id) + 1;
            _books.Add(book);
            return book;
        }

        public static List<Book> getAll()
        {
            return _books.ToList();
        }

        public static Book GetById(int id)
        {
            return _books.Where(x => x.Id == id).FirstOrDefault();
        }

        public static bool Remove(int id)
        {
            return _books.Remove(GetById(id));
        }

        public static void Update(Book book)
        {
            Book bookToUpdate = _books.Where(x => x.Id == book.Id).FirstOrDefault();
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.NumberOfPages = book.NumberOfPages;
            bookToUpdate.Genre = book.Genre;

        }
    }
}
