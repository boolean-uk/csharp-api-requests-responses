using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IRepository3
    {
        public Book AddBook(Book book)
        {
            return BookCollection.AddBook(book);
        }

        public Book DeleteBook(string title)
        {
            return BookCollection.DeleteBook(title);
        }

        public List<Book> GetAllBooks()
        {
            return BookCollection.GetAll();
        }

        public Book GetBook(int id)
        {
            return BookCollection.GetBook(id);
        }

        public Book UpdateBook(int id, string updateTitle, int updateNumpages, string updateAuthor, string updateGenre)
        {
            return BookCollection.UpdateBook(id, updateTitle, updateNumpages, updateAuthor, updateGenre);
        }



    }
}
