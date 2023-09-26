
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace api_counter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();
        //prviate int _nextId = 1;

        public BookController() 
        {
            if(_books.Count == 0)
            {
                _books.Add(new Book() 
                {
                    Id = 1,
                    title="A Game of Thrones", 
                    numPages = 780, 
                    author="George R.R. Martin", 
                    genre="Fantasy" 
                });
            }
                        
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("addBook")]
        public async Task<IResult> AddBook(Book book)
        {
            
            _books.Add(book);
            return Results.Created($"https://localhost:7241/Book/addBook", book);
        }
        //public async Task<IActionResult> AddBook(Book book)
        //{
        //    if (book == null)
        //    {
        //        return BadRequest("Ongeldige invoer.");
        //    }

        //    // Genereer een nieuwe unieke ID voor het boek
        //    book.Id = Guid.NewGuid();

        //    // Voeg het boek toe aan de lijst van boeken
        //    _books.Add(book);

        //    // Retourneer een respons met het toegevoegde boek en een statuscode 201 Created
        //    return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("getBooks")]
        public async Task<IResult> GetBooks()
        {
            return Results.Ok(_books);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> GetABook(int id)
        {
            var books = _books.Where(b => b.Id == id).FirstOrDefault();
            return books != null ? Results.Ok(books) : Results.NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("updateBook")]
        public async Task<IResult> UpdateBook(int id, Book books)
        {
            var book = _books.Where(x => x.Id == id).FirstOrDefault();
            
            book.title = books.title != string.Empty ? books.title : book.title;
            book.numPages = books.numPages;
            book.author = books.author;
            book.genre = books.genre;            
            return Results.Created($"https://localhost:7241/Book/updateBook", book);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("deleteBook/{id}")]
        public async Task<IResult> DeleteStudent(int id)
        {
            var book = _books.Where(s => s.Id == id).FirstOrDefault();
            var result = _books.RemoveAll(s => s.Id == id);

            return result >= 0 && book != null ? Results.Ok(book) : Results.NotFound();
        }
    }
}
