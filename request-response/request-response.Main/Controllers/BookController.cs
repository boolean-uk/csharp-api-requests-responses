using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();
        public BookController()
        {
            if (_books.Count == 0)
            {
                _books.Add(new Book(1, "Harry Potter and the Philosopher's Stone", "J.K. Rowling", "Fantasy", 317));
                _books.Add(new Book(2, "Harry Potter and the Chamber of Secrets", "J.K. Rowling", "Fantasy", 377));
                _books.Add(new Book(3, "Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "Fantasy", 511));
                _books.Add(new Book(4, "Harry Potter and the Goblet of Fire", "J.K. Rowling", "Fantasy", 577));
                _books.Add(new Book(5, "Harry Potter and the Order of the Phoenix", "J.K. Rowling", "Fantasy", 717));
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllBooks()
        {
            return Results.Ok(_books);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddBook(Book book)
        {
            _books.Add(book);
            return Results.Created($"http://www.boolean.com/books/{book.title}", book);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> GetBookById(int id)
        {
            var book = _books.Where(b => b.id == id).FirstOrDefault();
            return book != null ? Results.Ok(book) : Results.NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> DeleteBook(int id)
        {
            var book = _books.Where( b=> b.id == id).FirstOrDefault();
            int result = _books.RemoveAll(b => b.id == id);
            return result >= 0 && book != null ? Results.Ok(book) : Results.NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> UpdateBook(int id, Book book)
        {
            var item = _books.Where(b => b.id == id).FirstOrDefault();

            if (item == null) return Results.NotFound();

            if (book.id != 0) 
            {
                item.id = book.id;
            }

            return Results.Created($"http://www.boolean.com/books/{book.id}", book);
        }
    }
}