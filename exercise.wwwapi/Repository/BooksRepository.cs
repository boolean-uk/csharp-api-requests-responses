
namespace exercise.wwwapi
{
    public class BooksRepository
    {
        private readonly BookCollection _bookCollection;

        public BooksRepository(BookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public Book Add(Book book)
        {
            return _bookCollection.Add(book);
        }

        public List<Book> GetAll()
        {
            return _bookCollection.GetAll();
        }

        public Book Get(int id)
        {
            return _bookCollection.Get(id);
        }

        public Book Update(int id, string newTitle, int newNumPages, string newAuthor, string newGenre)
        {
            var book = _bookCollection.Get(id);

            if (book == null)
            {
                return null;
            }

            return _bookCollection.Update(id, newTitle, newNumPages, newAuthor, newGenre);
        }

        public bool Delete(int id)
        {
            return _bookCollection.Delete(id);
        }
    }
}
