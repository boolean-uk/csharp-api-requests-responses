using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using static exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _bookCollection;

        public BookRepository(BookCollection bookCollection)
        {
            _bookCollection = bookCollection;

        }
        public IEnumerable<Book> GetBooks()
        {
            return _bookCollection.GetBooks();
        }

        public Book AddBook(MakeBook make)
        {
            return _bookCollection.AddBook(make);
        }
        public Book GetBook(int id)
        {
            return _bookCollection.GetBook(id);
        }

        public Book UpdateBook(int id, MakeBook makeBook)
        {
            return _bookCollection.UpdateBook(id, makeBook);

        }

        public Book DeleteBook(int id)
        {
            return _bookCollection.DeleteBook(id);
        }



    }
}
