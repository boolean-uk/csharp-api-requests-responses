using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private T? validateNotNull<T>(T? val, ref bool fail)
        {
            if (val == null)
                fail = true;
            return val;
        }
        private bool ViewToBook(BookView bookView, ref Book book)
        {
            bool fail = false;
            book.title   = bookView.title ?? validateNotNull(book.title, ref fail);
            book.author  = bookView.author ?? validateNotNull(book.author, ref fail);
            book.numPages= bookView.numPages ?? validateNotNull(book.numPages, ref fail);
            book.genre   = bookView.genre ?? validateNotNull(book.genre, ref fail);
            
            return !fail;
        }
        public Book? AddBook(BookView bookview)
        {
            var book = new Book();
            if (ViewToBook(bookview, ref book))
                return BookCollection.Add(book);

            return null;
        }

        public Book? DeleteBook(string name)
        {

            return BookCollection.Remove(name);
        }

        public Book? GetBook(string name)
        {
            List<Book> bookWithSameName = new();
            if (BookCollection.GetBook(name, out bookWithSameName))
            {
                // If multiple with same name, pick first...
                return bookWithSameName.First();
            }

            return null;
        }

        public IEnumerable<Book> GetBooks()
        {
            return BookCollection.getAll();
        }

        public Book? UpdateBook(string name, BookView bookView)
        {
            Book stud = BookCollection.Remove(name);
            if (stud == null)
                return null;

            if (ViewToBook(bookView, ref stud))
                stud = BookCollection.Add(stud);

            return stud;

        }
    }
}
