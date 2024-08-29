using exercise.wwwapi.Models;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>
        {
            new Book(1, "A Game of Thrones", 780, "George R.R. Martin", "Fantasy")
        };

        public static int IdCounter = 2;

        public static int GetLength()
        {
            return _books.Count;
        }
        public static List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public static Book GetABook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public static Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public static Book RemoveBook(Book book)
        {
            _books.Remove(book);
            return book;
        }

        public static int IncreaseId()
        {
            IdCounter += 1;
            return IdCounter;
        }

        public static Book UpdateBook(int id, string title, int numPages, string author, string genre)
        {
            Book bookToBeUpdated = _books.FirstOrDefault(b => b.Id == id);

            if(bookToBeUpdated == null)
            {
                return null;
            }

            bookToBeUpdated.Title = title;
            bookToBeUpdated.NumPages = numPages;
            bookToBeUpdated.Author = author;
            bookToBeUpdated.Genre = genre;

            return bookToBeUpdated;
        }
    }
}
