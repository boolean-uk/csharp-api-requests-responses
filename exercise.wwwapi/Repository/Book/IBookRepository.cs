using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        
        public Book? GetBook(int id); 

        public Book AddBook(string title, int numPage, string author, string genre);

        public Book? UpdateBook(int id, BookUpdatePayload bookUpdatePayload);

        public Book? DeleteBook(int id);

    }
}