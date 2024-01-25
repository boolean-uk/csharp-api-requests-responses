using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository<T>
    {
        T GetBook(int id);
        IEnumerable<T> GetAllBooks();
        T AddBook(T book);
        T UpdateBook(int id, T book);
        T DeleteBook(int id);

    }
}
