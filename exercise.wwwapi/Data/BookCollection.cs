using System;
using System.Collections.Generic;
using System.Linq;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IColl<Book>
    {
        private List<Book> _books = new List<Book>()
        {
            new Book() { Id = 1, Title = "IT", Author = "King", NumPages = 600, Genre = "Horror" },
            new Book() { Id = 2, Title = "Dune", Author = "Herbert", NumPages = 1600, Genre = "Science Fiction" }
        };

        public Book Add(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.ToList();
        }

        public Book GetById(object id)
        {
            return _books.FirstOrDefault(book => book.Id == (int)id);
        }

        public Book Remove(object id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return book;
        }

        public Book Update(Book entity)
        {
            var book = GetById(entity.Id);
            if (book != null)
            {
                book.Title = entity.Title;
                book.Author = entity.Author;
                book.NumPages = entity.NumPages;
                book.Genre = entity.Genre;
            }
            return book;
        }

        public Book Update(object id, Book bookBody)
        {
            var book = GetById(id);
            if (book != null)
            {
                book.Title = bookBody.Title;
                book.Author = bookBody.Author;
                book.NumPages = bookBody.NumPages;
                book.Genre = bookBody.Genre;
            }
            return book;
        }
    }
}
