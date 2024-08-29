using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>(){
            new Book() { id = 1, title = "A Game of Thrones", numPages = 780, author = "George R.R. Martin", genre = "Fantasy"},
            new Book() { id = 2, title = "Harry Potter and the Philosophers Stone", numPages = 223, author = "J.K. Rowling", genre = "Fantasy"}
        };

        private static int _GenerateID() //Generate a unique ID to give to a book that gets added
        {
            int id = 0;
            while (true)
            {
                bool found = false;
                for (int i = 0; i < _books.Count; i++)
                {
                    if (id == _books[i].id) //ID was not unique
                    {
                        found = true;
                        id++;
                        break;
                    }
                }
                if(!found) //id is unique
                {
                    return id;
                }
            }
        }

        public static Book Add(BookPayload book) //Add the given book to the list
        {
            int id = _GenerateID();
            Book newBook = new Book() { id = id, title = book.title, numPages = book.numPages, author = book.author, genre = book.genre };
            _books.Add(newBook);

            return newBook;
        }

        public static List<Book> GetAll() //Get all books in the list
        {
            return _books;
        }

        public static Book Get(int id) //Get the book with the given id
        {
            var book = _books.FirstOrDefault(x => x.id == id);
            return book;
        }

        public static Book Remove(int id) //Remove the book with the given id
        {
            var book = _books.FirstOrDefault(x => x.id == id);
            _books.Remove(book);
            return book;
        }

        public static Book Update(BookPayload newBook, int id) //Replace the book that has the given name with the new book
        {
            int index = _books.IndexOf(_books.FirstOrDefault(x => x.id == id));
            if (index != -1)
            {
                Book newBookWithID = new Book() { id = _books[index].id, title = newBook.title, numPages = newBook.numPages, author = newBook.author, genre = newBook.genre };
                _books[index] = newBookWithID;
            }
            return _books[index];
        }
    }
}
