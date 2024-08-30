using exercise.wwwapi.Models;
using Microsoft.AspNetCore.SignalR;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        public static List<Book> books = new List<Book>()
        {
            new Book() {Id = 1, Title = "The Name of the Wind", NumPages = 662, Author ="Patrick Rothfuss", Genre ="Fantasy"},
            new Book() {Id = 2, Title = "The Wise Man's Fear ", NumPages = 1008, Author ="Patrick Rothfuss", Genre ="Fantasy"}
        };

        public static List<Book> GetAll()
        {
            return books.ToList();
        }
        public static Book Add(Book book)
        {
            books.Add(book);
            return book;
        }
        public static Book Get(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }
        public static Book Update(Book newBook, int id)
        {
            Book book = Get(id);
            book.Title = newBook.Title;
            book.NumPages = newBook.NumPages;
            book.Author = newBook.Author;
            book.Genre = newBook.Genre;
            return book;
        }

        public static Book Delete(int id)
        {
            Book book = Get(id);
            books.Remove(book);
            return book;
        }
    }
}
