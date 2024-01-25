using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetList();
        public Book Get(int id);

        public Book Create(BookPost model);

        public Book Update(int id, BookPost model);

        public Book Delete(int id);
    }
}
