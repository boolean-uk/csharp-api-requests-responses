using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        public List<Book> library = new List<Book>()
        {
            new Book() { Id = 1 , Title = "A Game of Thrones", numPages = 780, author = "George R.R. Martin", genre = "Fantasy" }
        };
    }
}
