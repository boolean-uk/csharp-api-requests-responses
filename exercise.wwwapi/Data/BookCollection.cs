using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        int idCounter = 1;
        private List<Book> _books = new List<Book>()
        {
            new Book("Name", 500, "Author", "Fantasy", 600)
        };

        public Book Add(BookPayload data)
        {
            Book newBook = new Book(data.title, data.numPages, data.author, data.genre, idCounter);
            idCounter++;
            _books.Add(newBook);
            return newBook;
        }
        public List<Book> GetBooks()
        {
            return _books;
        }
        public Book? GetBookByID(int id)
        {
            Book? result = _books.Find(x  => x._id == id);
            return result;
        }
        public Book Update(int id,  BookUpdatePayload data)
        {
            Book? result = _books.Find(x => x._id == id);
            if (result is null) throw new Exception();
            if (data.title != null) result._title = data.title;
            if (data.numPages != null) result._numPages = (int)data.numPages;
            if (data.author != null) result._author = data.author;
            if (data.genre != null) result._genre = data.genre;
            return result;
        }
        public Book Delete(int id)
        {
            Book? result = _books.Find(x => x._id == id);
            if (result is null) throw new Exception();
            _books.Remove(result);
            return result;
        }
    }
}
