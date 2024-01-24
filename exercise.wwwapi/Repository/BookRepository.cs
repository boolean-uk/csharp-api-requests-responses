using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _bookCollection;

        public BookRepository(BookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public InternalBook Create(ExternalBook book)
        {
            return _bookCollection.Add(book);
        }

        public InternalBook Delete(int id)
        {
            return _bookCollection.Remove(id);
        }

        public IEnumerable<InternalBook> Get()
        {
            return _bookCollection.Get();
        }

        public InternalBook Get(int id)
        {
            return _bookCollection.Get(id);
        }

        public InternalBook Update(int id, ExternalBook book)
        {
            return _bookCollection.Update(id, book);
        }
    }
}
