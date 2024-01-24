using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public Book CreateABook(BookPostPayload bookPost);

        public List<Book> GetAllBooks();

        public Book? GetABook(int id);

        public Book? UpdateABook(int id, BookUpdateData updateData);

        public Book DeleteABook(int id);
    }
}
