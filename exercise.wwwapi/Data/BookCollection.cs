using exercise.wwwapi.Models;
using System.Collections.ObjectModel;

namespace exercise.wwwapi.Data
{
    public class BookCollection : IBookDB
    {
        private static List<Book> _collection = new List<Book>(){

            new Book() { Id = 1, Title ="A Game of Thrones",NumPages= 780, Author="George R.R. Martin",Genre= "Fantasy" },
            new Book() { Id = 2, Title ="A Game of Trombones",NumPages= 822, Author="George T.R. Ombone",Genre= "Biography" }
        };

        public IEnumerable<Book> GetObjects()
        {
            return _collection;
        }
        public Book CreateObject(BookPost model) {
            int id = _collection.Max(x => x.Id) +1;
            Book book = new Book() {Id = id, Title=model.Title,NumPages=model.numPages,Author=model.Author, Genre=model.Genre };
            _collection.Add(book);
        return book;
        }

        public Book UpdateObject(int id, BookPost model)
        {
            Book book = _collection.FirstOrDefault(x => x.Id == id);
            book.Title = model.Title;
            book.NumPages = model.numPages;
            book.Author = model.Author;
            book.Genre = model.Genre;
            return book;
        }
        public Book DeleteObject(int id) {

            Book book = _collection.FirstOrDefault(x => x.Id == id);
            _collection.Remove(book);
            return book;
        }


    }
}
