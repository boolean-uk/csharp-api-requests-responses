using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace request_response.Controllers
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
    /// Used DTO object to define data
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();

        static BooksController() // Harry Potter Books ofcours
        {
            if (!_books.Any())
            {
                _books.Add(new Book() { Id = 1, Title = "Harry Potter and the Philosopher's Stone", NumPages = 223, Author = "J.K. Rowling", Genre = "Fantasy" });
                _books.Add(new Book() { Id = 2, Title = "Harry Potter and the Chamber of Secrets", NumPages = 251, Author = "J.K. Rowling", Genre = "Fantasy" });
                _books.Add(new Book() { Id = 3, Title = "Harry Potter and the Prisoner of Azkaban", NumPages = 317, Author = "J.K. Rowling", Genre = "Fantasy" });
                _books.Add(new Book() { Id = 4, Title = "Harry Potter and the Goblet of Fire", NumPages = 636, Author = "J.K. Rowling", Genre = "Fantasy" });
                _books.Add(new Book() { Id = 5, Title = "Harry Potter and the Order of the Phoenix", NumPages = 766, Author = "J.K. Rowling", Genre = "Fantasy" });
                _books.Add(new Book() { Id = 6, Title = "Harry Potter and the Half-Blood Prince", NumPages = 607, Author = "J.K. Rowling", Genre = "Fantasy" });
                _books.Add(new Book() { Id = 7, Title = "Harry Potter and the Deathly Hallows", NumPages = 607, Author = "J.K. Rowling", Genre = "Fantasy" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateBook(CreateBook book)
        {
            return await Task.Run(() =>
            {
                var newBook = new Book
                {
                    Id = _books.Count + 1,
                    Title = book.Title,
                    NumPages = book.NumPages,
                    Author = book.Author,
                    Genre = book.Genre
                };

                _books.Add(newBook);
                return Results.Created($"/books/{newBook.Id}", newBook);
            });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllBooks()
        {
            return await Task.FromResult(Results.Ok(_books));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetBookById(int id)
        {
            return await Task.Run(() =>
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(book);
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> UpdateBook(int id, CreateBook updatedBook)
        {
            return await Task.Run(() =>
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound();
                }

                book.Title = updatedBook.Title;
                book.NumPages = updatedBook.NumPages;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;

                return Results.Created($"/books/{book.Id}", book);
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> DeleteBook(int id)
        {
            return await Task.Run(() =>
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound();
                }

                _books.Remove(book);
                return Results.Ok(book);
            });
        }
    }
}