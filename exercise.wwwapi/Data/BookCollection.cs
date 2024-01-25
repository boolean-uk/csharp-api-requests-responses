using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.OrderBy(b => b.Id);
        }

        public Book AddBook(BookDraft newBook)
        {
            Book book = null;
            if (ValidateBook(newBook))
            {
                book = new Book(GetNextAvailableIndex(), newBook.Title, newBook.NumPages, newBook.Author, newBook.Genre);
                _books.Add(book);
            }

            return book;
        }

        public bool ValidateBook(BookDraft book) 
        {
            if (book.Title == null || book.Author == null || book.Genre == null)
            {
                return false;
            }
            return true;
        }

        public Book RemoveBook(Book book)
        {
            _books.Remove(book);
            return book;
        }

        /// <summary>
        /// Retrieve the smallest next available integer. 
        /// Makes a list of all int from 1 to _books.Count+1 then removes all int's that are contained within the Book.Id's in the collection.
        /// After the common ints are removed the first (and smallest) element gets selected.
        /// </summary>
        /// <returns> int - Smallest available int </returns>
        private int GetNextAvailableIndex() 
        {
            int lowestNonUsedInt = Enumerable.Range(1, _books.Count + 1).Except(_books.Select(b => b.Id)).FirstOrDefault();
            return lowestNonUsedInt;
        }
    }
}
