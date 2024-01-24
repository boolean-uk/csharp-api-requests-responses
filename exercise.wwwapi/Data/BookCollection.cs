using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private List<Book> books = new List<Book>();

        public List<Book> GetAll()
        {
            return books;
        }

        public Book Add(Book book)
        {
            books.Add(book);
            return book;
        }

        public bool Delete(Book book)
        {
            return books.Remove(book);
        }
    }
}
