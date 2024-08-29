using exercise.wwwapi.Models;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> _books = new List<Book>
        {
            new Book(1, "A Game of Thrones", 780, "George R.R. Martin", "Fantasy")
        };

        public int GetLength()
        {
            return _books.Count;
        }
        public List<Book> GetBooks()
        {
            return _books.ToList();
        }

        public Book GetABook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        public Book RemoveBook(Book book)
        {
            _books.Remove(book);
            return book;
        }


    }
}
