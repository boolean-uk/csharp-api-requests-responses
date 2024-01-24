using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class Library
    {
        private List<Book> _books = new List<Book>(){
            new Book(){
                Id = 1,
                Title="Star War",
                Author="George RR Marvin",
                NumPages=3,
                Genre="True story"
            },
            new Book(){
                Id = 2,
                Title="Lord of the Bling",
                Author="Amazon",
                NumPages=9,
                Genre="Dripped out fantasy"
            },
            new Book(){
                Id = 3,
                Title="Timothy Chalamets Reflections on Life",
                Author="Jimothy Chalamet",
                NumPages=80,
                Genre="Grindset"
            },
        };

        public List<Book> AllBooks()
        {
            return _books;
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public Book UpdateBook(int id, BookPut book)
        {
            var bookToUpdate = _books.Find(x => x.Id == id);
            if (bookToUpdate == null)
            {
                return null;
            }
            bookToUpdate.Author = book.Author;
            bookToUpdate.NumPages = (int)book.NumPages;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Genre = book.Genre; 

            return bookToUpdate;
        }

        public Book AddBook(Book book)
        {
            Book newBook = new Book()
            {
                Id = _books.Count() + 1,
                Title = book.Title,
                Author = book.Author,
                NumPages = book.NumPages,
                Genre = book.Genre
                
            };
            _books.Add(newBook);
            return newBook;
        }

        public Book DeleteBook(int id) 
        {
            Book bookToDelete = _books.FirstOrDefault(x => x.Id == id);
            _books.Remove(bookToDelete);
            return bookToDelete;
        }
    }
}
