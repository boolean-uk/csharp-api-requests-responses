using api_counter.Models;
using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public static List<Book> books = new List<Book>();
        public BookController()
        {
            if (books.Count == 0)
            {
                books.Add(new Book("LOTR", 1000,"George RR Martin", "Fantasy"));
                books.Add(new Book("The Hoobit", 900, "George RR Martin", "Fantasy"));
            }
        }

        //post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateBook(Book book)
        {
            try
            {
                if (book != null)
                {
                    int id = books.Count == 0 ? 1 : books.Max(x => x.Id) + 1;
                    book.Id = id;
                    books.Add(book);
                }
                return Results.Ok(book);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        //get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetBooks()
        {
            return Results.Ok(books);
        }

        //get{firstname}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> GetABook(int id)
        {
            var book = books.Where(s => s.Id == id).FirstOrDefault();
            return book != null ? Results.Ok(book) : Results.NotFound();
        }

        //update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IResult> Update(int id, Book book)
        {
            //get item to update
            var item = books.Where(s => s.Id == id).FirstOrDefault();

            if (item == null) return Results.NotFound();

            item.title = string.IsNullOrEmpty(book.title) ? item.title : book.title;
            item.numPages = book.numPages;
            item.genre = string.IsNullOrEmpty(book.genre) ? item.genre : book.genre;

            return Results.Ok(item);
        }

        //delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> DeleteABook(int id)
        {
            var book = books.Where(s => s.Id == id).FirstOrDefault();
            int result = books.RemoveAll(s => s.Id == id);
            return result >= 0 && book != null ? Results.Ok(book) : Results.NotFound();
        }






    }
}
