using api_counter.Models;
using api_counter.Models.requests;
using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace api_counter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        public static List<Book> _books = new List<Book>();

        public BooksController() { }



        [HttpPost]
        public IActionResult Create(BookRequest book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book info is not provided");
                }
                var newBook = new Book
                {
                    Id = Guid.NewGuid(),
                    Author = book.Author,
                    Genre = book.Genre,
                    NumPages = book.NumPages,
                    Title = book.Title

                };
                _books.Add(newBook);
                return Ok(newBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_books);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var book = _books.FirstOrDefault(x => x.Id == id);
                return book != null ? Ok(book) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] BookRequest book)
        {
            try
            {
                var b = _books.SingleOrDefault(x => x.Id == id);
                if (b is not null)
                {
                    b.Author = book.Author;
                    b.Title = book.Title;
                    b.NumPages = book.NumPages;
                    b.Genre = book.Genre;
                    
                    return Ok(b);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute(Name = "Id")]Guid id)
        {
            try
            {
                if (_books.Any(x => x.Id == id))
                {
                    _books.RemoveAll(x => x.Id == id);
                    return Ok();
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
