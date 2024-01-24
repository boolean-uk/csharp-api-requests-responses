using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{



    public class BookCollection
    {
        private List<Book> books = new List<Book>();


        public BookCollection() {
            Book book = new Book("A Game of Thrones", 780, "George R.R. Martin", "Fantasy");

            books.Add(book);
        }
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
        public Book? FindById(int id)
        {
            return books.FirstOrDefault(book => book.Id == id);
        }
    }
}
