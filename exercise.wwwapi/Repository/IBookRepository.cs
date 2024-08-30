using exercise.wwwapi.Models;
namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book DeleteBook(string title);
        Book GetABook(string title);
        List<Book> GetAllBooks();
        Book PostABook(string title, int numPages, string author, string genre);
        Book UppdateBook(string title, string newtitle, int? newnumPages, string newauthor, string newgenre);
    }
}
