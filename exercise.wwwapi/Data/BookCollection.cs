using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new()
        { };


        public static Book Add(Book book)
        {
            
            book.Id = _books.Any() ? _books.Max(x => x.Id) + 1: 1;
            _books.Add(book);

            return book;
        }

        public static List<Book> GetAll()
        {
            return _books;
        }
        public static Book GetABook(string id)
        {
            int idNumber = Int32.Parse(id); 
            Book result = _books.FirstOrDefault(x => x.Id == idNumber);
            return result;
        }

        public static Book Change(int id, Book entity)
        {
            
            var result = _books.FirstOrDefault(x => x.Id == id);

            result.Id = entity.Id;
            result.title = entity.title;
            result.author = entity.author;
            result.genre = entity.genre;
            result.numPages = entity.numPages;

            return entity;
        }
        public static int Delete(int search)
        {
            foreach(var book in _books)
            {
                if(book.Id == search)
                {
                    _books.Remove(book);
                    return search;
                }
            }
            return -1;
        }
    }
}
