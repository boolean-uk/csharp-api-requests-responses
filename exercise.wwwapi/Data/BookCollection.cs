using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        public List<Book> _books { get; set; } = new List<Book>();

        public BookCollection() 
        {
            Book book1 = new Book()
            {
                id = 1,
                title = "harry potter",
                numPages = 700,
                author = "J.K rowling",
                genre = "Action"
            };
            Book book2 = new Book()
            {
                id = 2,
                title = "The Adventures of Sherlock Holmes ",
                numPages = 1000,
                author = "Arthur Conan Doyle",
                genre = "short story"
            };
            this._books.Add(book1);
            this._books.Add(book2);
        }
    }
}
