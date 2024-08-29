using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book CreateABook(Book book)
        {
            return BookCollection.CreateABook(book);
        }

        public Book DeleteBook(int id)
        {
            return BookCollection.DeleteBook(id);
        }

        public Book GetABook(int id)
        {
            return BookCollection.GetABook(id);
        }

        public List<Book> GetAllBooks()
        {
            return BookCollection.GetAllBooks();
        }

        public Book UpdateBook(int id, string newTitle, int newNumPages, string newAuthor, string newGenre)
        {
            return BookCollection.UpdateBook(id, newTitle, newNumPages, newAuthor, newGenre);
        }
    }
}
