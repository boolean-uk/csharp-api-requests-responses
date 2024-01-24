using exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> _books;
        private int _id = 0;

        public BookCollection() {
            _books = new List<Book>()
            {
                new Book() {Id = getNextId(), Title = "API:s Workings", Author="Vincent Werelius", Genre="Documentary", TotalPages=500 },
            };
            
        }

        public Book AddBook(BookPostPayload payload)
        {
            var newBook = new Book() { Id = getNextId(), Title = payload.Title, Author = payload.Author, Genre = payload.Genre, TotalPages = payload.pages };
            _books.Add(newBook);
            return newBook;
        }

        private int getNextId()
        {
            return _id++;
        }

        public List<Book> getAllBooks() {
            return _books;
        }

        public Book getBookById(int _id)
        {
            return _books.Find(b => b.Id == _id);
        }

        public Book UpdateBookById(int _id, BookPutPayload payload)
        {
            var updatedBook = getBookById(_id);
            if (updatedBook == null) {
                return null;
            }

            if (payload != null)
            {
                if (payload.Title != null && payload.Title.Length > 0) {
                    updatedBook.Title = payload.Title;
                }
                if (payload.Author != null && payload.Author.Length > 0)
                {
                    updatedBook.Author = payload.Author;
                }
                if (payload.Genre != null && payload.Genre.Length > 0)
                {
                    updatedBook.Genre = payload.Genre;   
                }
                if (payload.Pages != null && payload.Pages.Value > 0)
                {
                    updatedBook.TotalPages = payload.Pages.Value;
                }
                
                return updatedBook;
            }
            throw new Exception("No changes have been entered");
        }

        public void DeleteBookById(int _id)
        {
            var deletedBook = getBookById(_id);
            if (deletedBook != null) { _books.Remove(deletedBook); }
            
        }

    }
}
