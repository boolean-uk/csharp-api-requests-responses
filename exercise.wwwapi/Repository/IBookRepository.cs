using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public InternalBook Create(ExternalBook book);
        public IEnumerable<InternalBook> Get();
        public InternalBook Get(int id);
        public InternalBook Update(int id, ExternalBook book);
        public InternalBook Delete(int id);
    }
}
