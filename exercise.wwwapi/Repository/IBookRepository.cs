using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public Book Create(BookDTO book);

        public List<Book> GetAll();
        public Book Get(int id);
        //public Book Update(int id, Book book);
        //public Book Delete(int id);
    }
}
