using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IBookCollection<T>
    {
        IEnumerable<T> GetAllBooks();
        T GetBook(int id);
        T AddBook(T book);
        T UpdateBook(int id, T book);
        T DeleteBook(int id);
    }
}
