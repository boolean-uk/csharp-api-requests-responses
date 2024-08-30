using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Reposity
{
    public class BookRepository : IRepository<Book>
    {
        public Book Add(Book item)
        {
            BookCollection.Add(item);
            return item;
        }

        public Book Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public Book Delete(int Id)
        {
            Book book = BookCollection.Delete(Id);
            return book;
        }

        public Book Get(string itemName)
        {
            throw new NotImplementedException();
        }

        public Book Get(int Id)
        {
            Book book = BookCollection.Get(Id);
            return book;
        }

        public List<Book> getAll()
        {
            return BookCollection.getAll();
        }

        public Book Update(string itemName, Book item)
        {
            throw new NotImplementedException();
        }

        public Book Update(int Id, Book item)
        {
            return BookCollection.Update(Id, item);
        }
    }
}
