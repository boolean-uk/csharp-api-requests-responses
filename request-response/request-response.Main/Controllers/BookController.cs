using api_counter.Models;
using Microsoft.AspNetCore.Mvc;
using request_response.Models;
using System.ComponentModel.DataAnnotations;

namespace api_counter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>();
        private static int bookId = 1;

        public BookController()
        {
        }

        [HttpPost]
        [Route("/books")]
        public async Task<IResult> AddBook([Required] string title, [Required] int numPages, [Required] string author, [Required] string genre)
        {
            try
            {
                Book book = new Book(bookId, title, genre, author, numPages);
                bookId++;
                books.Add(book);
                return Results.Created($"https://localhost:7241/books/{book._id}", book);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/books")]
        public async Task<IResult> GetAllBooks()
        {
            try
            {
                if (books.Count > 0)
                {
                    return Results.Ok(books);
                }
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/books/{id}")]
        public async Task<IResult> GetBookById([Required] int id)
        {
            try
            {
                foreach (Book i in books)
                {
                    if (i._id == id)
                    {
                        return Results.Ok(i);
                    }
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/books/{id}")]
        public async Task<IResult> DeleteBookById([Required] int id)
        {
            try
            {
                foreach (Book i in books)
                {
                    if (i._id == id)
                    {
                        books.Remove(i);
                        return Results.Ok(i);
                    }
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("/books/{id}")]
        public async Task<IResult> UpdateBook([Required] int id, string? title, string? author, int? numpages)
        {
            try
            {
                if (books.Any(i => i._id == id))
                {
                    var b = books.SingleOrDefault(i => i._id == id);
                    if (b != null)
                    {
                        if (!string.IsNullOrEmpty(title))
                        {
                            b._title = title;
                        }
                        if (!string.IsNullOrEmpty(author))
                        {
                            b._author = author;
                        }
                        if (numpages != null && numpages.HasValue)
                        {
                            b._pages = (int)numpages;
                        }
                        return Results.Ok(b);
                    }

                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
