using exercise.wwwapi.Models.Book;
using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Repository.Interfaces
{
    public interface IBookRepo : IRepository<Book>
    {
        public Book Add(BookPayload payLoad);

        public Book Update(int id, BookPayload updatePayload);

        public Book Get(int id);

        public Book Remove(int id);
    }
}
