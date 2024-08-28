using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _bookCollection;

        private int _nextId = 1;

        public BookRepository(BookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public Book Create(BookDTO bookDTO)
        {
            var book = new Book(
            id: _nextId,  
            title: bookDTO.Title,
            numPages: bookDTO.NumPages,
            author: bookDTO.Author,
            genre: bookDTO.Genre 
            );

            _nextId++;

            return _bookCollection.Add(book);
        }

        public List<Book> GetAll()
        {

            return _bookCollection.GetAll();
        }

        public Book Get(int id)
        {
            return _bookCollection.Get(id);
        }

    }
}
