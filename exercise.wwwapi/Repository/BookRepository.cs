using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private IBookDB _collection;

        public BookRepository(IBookDB BookCollection)
        {
            _collection = BookCollection;
        }
        public IEnumerable<Book> GetList()
        {
            return _collection.GetObjects();
        }
        public Book Get(int id)
        {
            Book book = _collection.GetObjects().FirstOrDefault(b => b.Id.Equals(id));
            return book;
        }

        public Book Create(BookPost model)
        {
            Book book = _collection.CreateObject(model);
            return book;
        }

        public Book Update(int id,BookPost model)
        {

            Book updatedLanguage = _collection.UpdateObject(id, model);
            return updatedLanguage;
        }

        public Book Delete(int id)
        {

            Book DeletedLanguage = _collection.DeleteObject(id);

            return DeletedLanguage;
        }
    }
}
