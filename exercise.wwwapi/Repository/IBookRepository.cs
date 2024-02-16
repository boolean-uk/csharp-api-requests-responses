using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book AddBook(BookCreatePayload bookData);
        Book GetBook(int id);
        Book UpdateBook(int id, BookUpdatePayload updateData);
        Book DeleteBook(int id);
    }
}
