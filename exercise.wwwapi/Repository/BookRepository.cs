﻿using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book AddBook(Book book)
        {
            return BookCollection.Add(book);
        }

        public Book DeleteBook(int id)
        {
            return BookCollection.DeleteBook(id);
        }

        public Book GetBook(int id)
        {
            return BookCollection.GetBook(id);
        }

        public List<Book> GetBooks()
        {
            return BookCollection.GetAll();
        }

        public Book UpdateBook(int id, Book book)
        {
            return BookCollection.UpdateBook(id, book);
        }
    }
}
