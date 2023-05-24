using api_counter.Models;
using Microsoft.AspNetCore.Mvc;
using request_response.Models;
using System.Linq.Expressions;

namespace api_counter.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public BookController()
        {
        }

        [HttpPost]
        public async Task<IResult> CreateBook(Book book)
        {
            try
            {
                if (book != null)
                {
                    book.Id = Books.Count>0 ? Books.Max(x => x.Id) + 1 : 1;
                    Books.Add(book);
                    return Results.Created("https://localhost:7241/Books", book);
                }
                else
                {
                    return Results.Problem("Book was empty");
                }           
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> GetBooks()
        {
            try
            {
                if (Books.Count != 0)
                {
                    return Results.Ok(Books);
                }
                else
                {
                    return Results.Problem("There are no books yet");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetBook(int id)
        {
            try
            {
                var book = Books.FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    return Results.Ok(book);
                }
                else
                {
                    return Results.Problem($"There is no book with id: {id}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IResult> UpdateBook(Book book, int id)
        {
            try
            {
                var b = Books.FirstOrDefault(x => x.Id == id);
                if (b != null)
                {
                    b.NumPages = book.NumPages;
                    b.Title = book.Title;
                    //if (book.Author)
                    b.Author = book.Author;
                    b.Genre = book.Genre;
                    return Results.Ok(b);
                }
                else
                {
                    return Results.Problem($"There is no book with id: {id}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> DeleteBook(int id)
        {
            try
            {
                var book = Books.FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    Books.Remove(book);
                    return Results.Ok(book);
                }
                else
                {
                    return Results.Problem($"There is no book with id: {id}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
