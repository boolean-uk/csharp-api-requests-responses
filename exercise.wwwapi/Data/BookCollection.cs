using exercise.wwwapi.Models;
using System.Linq;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> books = new List<Book>();

        public Book AddBook(string title, int numPages, string author, string genre)
        {
            Book book = new Book(title, numPages, author, genre);
            book.Id = (books.Count());
            books.Add(book);
            return book;
        }

        public List<Book> GetBooks() 
        {  
            return books; 
        }
    }

}
