using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book Create(BookPayload payload)
        {
            return BookCollection.Add(payload);
        }

        public Book Delete(int identifier)
        {
            return BookCollection.Remove(identifier);
        }

        public Book Get(int identifier)
        {
            return BookCollection.Get(identifier);
        }

        public List<Book> GetAll()
        {
            return BookCollection.GetAll();
        }

        public Book Update(BookPayload entity, int identifier)
        {
            return BookCollection.Update(entity, identifier);
        }
    }
}
