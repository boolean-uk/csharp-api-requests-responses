using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IData<Book>
    {
        private List<Book> _books = [];
        private int idNum = 0;
        public Book Add(Book book)
        {
            book.Id = idNum++;
            _books.Add(book);
            return book;
        }

        public Book Delete(string id)
        {
            Book dbBook = _books.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
            if (dbBook == null) { return null; }
            _books.Remove(dbBook);
            return dbBook;
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetSpecific(string id)
        {
            return _books.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
        }

        public Book Update(string id, Book newInfo)
        {
            Book dbBook = _books.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
            if (dbBook == null) { return null; }
            dbBook.Author = newInfo.Author;
            dbBook.Title = newInfo.Title;
            dbBook.NumPages = newInfo.NumPages;
            dbBook.Genre = newInfo.Genre;
            return dbBook;
        }
    }
}
