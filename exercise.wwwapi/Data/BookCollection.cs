using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {

        private static List<Book> _books = new List<Book>()
        {
            new Book() { Id= 1,Title="The Hunger Games", NumPages =374 ,Author ="Suzanne Collins",Genre = "Science Fiction" },
            new Book() { Id=2, Title="Catching Fire", NumPages = 391, Author = "Suzanne Collins", Genre = "Science Fiction"}


        };

        public static Book AddBook(Book book)
        {

            int id = _books.Max(x => x.Id) + 1;
            book.Id = id;
            _books.Add(book);

            return book;
        }

        public static List<Book> GetAll()
        {
            return _books.ToList();
        }

        public static Book GetBook(int id)

        {

            return _books.FirstOrDefault(x => x.Id == id);

        }

        public static Book UpdateBook(int id, string updateTitle,int updateNumPages, string updateAuthor , string updateGenre)

        {
            Book book = GetBook(id);
            if (book != null)
            {
                book.Title = updateTitle;
                book.NumPages = updateNumPages;
                book.Author = updateAuthor;
                book.Genre = updateGenre;

                return book;

            }

            return null;
        }

        public static Book DeleteBook(string title)

        {
            Book book;
            foreach (var bk in _books)

            {
                if (bk.Title.Equals(title))
                {
                    book = bk;
                    _books.Remove(bk);

                    return book;

                }

            }
            return null;


        }


    }
}
