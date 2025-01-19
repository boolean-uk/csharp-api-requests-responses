using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository3
    {
        Book AddBook(Book book);
        List<Book> GetAllBooks();
        Book GetBook(int id);
        Book UpdateBook(int id, string updateTitle, int updateNumPages, string updateAuthor, string updateGenre);
        Book DeleteBook(string title);

        
    }
}
