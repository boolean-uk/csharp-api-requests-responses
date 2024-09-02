using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> Books = new List<Book>(){
            new Book { Id = 1, Title = "The Catcher in the Rye", Author = "J.D. Salinger", NumPages = 214, Genre = "Fiction" },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", NumPages = 328, Genre = "Dystopian" },
            new Book { Id = 3, Title = "A Game of Thrones", Author = "George R.R. Martin", Genre="Fantasy", NumPages=780}
        };
        public static List<Book> GetAll() => Books.ToList();
        public static Book GetA(int id)
        {
            Book book = Books.FirstOrDefault(x => x.Id == id);
            return book;
        }
        public static Book Update(int id, Book newBook)
        {
            var book = Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                Delete(book.Id);
                Create(newBook);
            }
            return book;
        }
        private static void Create(Book newBook)
        {
            Books.Add(newBook);
        }
        public static Book Delete(int id)
        {
            var book = GetA(id);
            if (book != null)
            {
                Books.Remove(book);
            }
            return book;
        }
    }
}