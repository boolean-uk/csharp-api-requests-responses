using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<InternalBook> _books = new List<InternalBook>(){
            new InternalBook("A Game of Thrones", 780, "George R.R. Martin","Fantasy")
        };

        public List<InternalBook> Get()
        {
            return _books;
        }

        public InternalBook Get(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public InternalBook Add(ExternalBook book)
        {
            InternalBook newBook = new InternalBook(book.Title, book.NumPages, book.Author, book.Genre);
            _books.Add(newBook);
            return newBook;
        }

        public InternalBook Update(int id, ExternalBook book)
        {
            InternalBook existingBook = _books.FirstOrDefault(b => b.Id == id);

            existingBook.Title = book.Title;
            existingBook.NumPages = book.NumPages;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;

            return existingBook;
        }

        public InternalBook Remove(int id)
        {
            InternalBook book = _books.FirstOrDefault(b => b.Id == id);
            _books.Remove(book);
            return book;
        }
    }
}
