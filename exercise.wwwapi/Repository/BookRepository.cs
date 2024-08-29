using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Helpers;
using System.Reflection.Emit;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IdGenerator _idGenerator;
        private BookCollection _bookCollection;

        public BookRepository(IdGenerator idGenerator, BookCollection bookCollection)
        {
            _idGenerator = idGenerator;
            _bookCollection = bookCollection;
        }

        public Book Create(BookDTO bookDTO)
        {

            var book = new Book(
            id: _idGenerator.GetNextId(),
            title: bookDTO.Title,
            numPages: bookDTO.NumPages,
            author: bookDTO.Author,
            genre: bookDTO.Genre
            );

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

        public Book Update(int idNum, BookDTO bookDTO)
        {
            var book = new Book(
            id: idNum,
            title: bookDTO.Title,
            numPages: bookDTO.NumPages,
            author: bookDTO.Author,
            genre: bookDTO.Genre
            );

            return _bookCollection.Update(idNum, book);
        }

        public Book Delete(int id)
        {

            return _bookCollection.Delete(id);
        }

    }
}
