using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class BookCollection
    {
        private List<Book> books = new List<Book>(){
            new Book("Java", 5, "Marcus", "IT", 52),
            new Book ("C#", 6, "Palm", "Fantacy", 37)
        };

        private int _id = 0;

        public Book AddBook(BookPostPayload bookData)
        {
            _id++;
            Book book = new Book(bookData.title,bookData.numPages,bookData.author,bookData.genre, _id);
            books.Add(book);
            return book;
        }

        public List<Book> getAllBooks()
        {
            return books.ToList();
        }

        public void RemoveABook(Book book)
        {
            books.Remove(book);
        }

        public Book GetABook(int id)
        {
            Book book = books.Find(x => x.ID == id);

            return book;
        }

        public Book UpdateABook(Book book ,BookUpdateData bookData)
        {
            books.Remove(book);
            book = new Book(bookData.title, bookData.numPages, bookData.author, bookData.genre, book.ID);
            books.Add(book);
            return book;
        }
    }
}
