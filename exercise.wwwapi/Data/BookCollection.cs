using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IBookRepository
    {
        private List<Book> _books = new List<Book>();
        private int _nextId = 1;

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public List<Book> GetAll()
        {
            return _books.ToList();
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book Update(int id , Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                book.Title = updatedBook.Title;
                book.NumPages = updatedBook.NumPages;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;
            }
            return book;
        }

        public Book Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                _books.Remove(book);
            }
            return book;
        }
    }
}
