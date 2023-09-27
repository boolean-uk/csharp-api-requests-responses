using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace api_counter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();

        public BookController()
        {
            
        }

        /// <summary>
        /// Add a new book to the list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="numPages"></param>
        /// <param name="author"></param>
        /// <param name="genre"></param>
        /// <returns>Url and object of book created</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateBook(String title, int numPages, string author, string genre)
        {
            Book book = new Book(title, numPages, author, genre);
            _books.Add(book);
            return Results.Created($"http://localhost:5186/Book/{book.Id}", book);
        }

        /// <summary>
        /// Get all books from the list
        /// </summary>
        /// <returns>List of all books</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetBooks()
        {
            return Results.Ok(_books);
        }

        /// <summary>
        /// Get a single book by its ID
        /// </summary>
        /// <param name="id">The ID of the book</param>
        /// <returns>The book with this ID</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book != null ? Results.Ok(book) : Results.NotFound();
        }

        /// <summary>
        /// Update a books details by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="numPages"></param>
        /// <param name="author"></param>
        /// <param name="genre"></param>
        /// <returns>Updated book object</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> UpdateBook(int id, String title, int numPages, string author, string genre)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return Results.NotFound();
            if (!string.IsNullOrEmpty(title))
                book.Title = title;
            if (numPages > 0)
                book.NumPages = numPages;
            if (!string.IsNullOrEmpty(author))
                book.Author = author;
            if (!string.IsNullOrEmpty(genre))
                book.Genre = genre;
            return Results.Created($"http://localhost:5186/Book/{book.Id}", book);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return Results.NotFound();
            return _books.Remove(book) ? Results.Ok(book) : Results.NotFound();
        }
    }
}
