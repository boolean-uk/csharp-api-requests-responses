using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.DTO;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookCollection _books;
        public BookRepository(BookCollection books) 
        {
            this._books = books;
        }

        public Book Create(API_book book) 
        {
            Book newBook = new Book()
            {
                id = this._books._books.Last().id + 1,
                title = book.title,
                numPages = book.numPages,
                author = book.author,
                genre = book.genre,
            };           
            this._books._books.Add(newBook);
            return newBook;
        }

        public List<Book> GetAllBooks()
        {
            return this._books._books;
        }

        public Book getBook(int id) 
        {
            Book book = this._books._books.First(x => x.id == id);
            return book;
        }

        public Book Update(int id, API_book book) 
        {
            Book retrievedBook = this._books._books.First(x => x.id == id);
            retrievedBook.title = book.title;
            retrievedBook.author = book.author;
            retrievedBook.genre = book.genre;
            retrievedBook.numPages = book.numPages;
            return retrievedBook;
        }

        public Book Delete(int id) 
        {
            Book retrievedBook = this._books._books.First(x => x.id == id);
            this._books._books.Remove(retrievedBook);
            return retrievedBook;
        }
    }
}
