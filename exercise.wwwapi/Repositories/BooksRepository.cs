using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BooksRepository
    {
        public List<Book> Add(Book book)
        {
            BookCollection.Add(book);
            return BookCollection.GetAll(); 
        }
        public Book Get(int id)
        {
            return BookCollection.Get(id);
        }
        public List<Book> GetAll()
        {
            {
                return BookCollection.GetAll();
            }


        }
        public List<Book> Uppdate(int id, string title, int numPages, string author, string genre)
        {
            BookCollection.Uppdate(id, title, numPages, author, genre);
            return BookCollection.GetAll();

        }
        public List<Book> Delete(int id)
        {
            BookCollection.Delete(id);
            return BookCollection.GetAll();
        }
    }
}
