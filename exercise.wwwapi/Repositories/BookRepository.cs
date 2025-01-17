using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        public Book Add(Book entity)
        {
            entity.Id = BookCollection.Books.Max(x => x.Id) + 1;
            BookCollection.Books.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            Book Book = Get(id);
            return BookCollection.Books.Remove(Book);
        }

        public Book Get(int id)
        {
            Book Book = BookCollection.Books.FirstOrDefault(x => x.Id == id);
            return Book ?? throw new ArgumentException("That ID does not exist!");
        }

        public Book Get(Func<Book, bool> condition)
        {
            Book Book = BookCollection.Books.Where(condition).FirstOrDefault();
            return Book ?? throw new ArgumentException("No Book fit that condition!");
        }

        public IEnumerable<Book> GetAll()
        {
            return BookCollection.Books;
        }

        public Book Update(int id, Book entity)
        {
            Book book = Get(id);
            book.Author = entity.Author ?? book.Author;
            book.Title = entity.Title ?? book.Title;
            book.Genre = entity.Genre ?? book.Genre;
            book.NumPages = entity.NumPages > 0 ? entity.NumPages : book.NumPages;
            return book;
        }
    }
}
