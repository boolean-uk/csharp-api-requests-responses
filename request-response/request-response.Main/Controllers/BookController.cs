using api_counter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System.ComponentModel.DataAnnotations;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>();
        private static int id = 1;
        public BookController()
        {
        }
        [HttpPost]
        [Route("/books")]
        public async Task<IResult> createBook([Required] string title, [Required] string author, [Required] string genre, [Required] int numPages)
        {
            try
            {
                Book book = new Book(id,title, author, genre, numPages);
                id++;
                books.Add(book);
                return Results.Created("ok", book);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/books/{id}")]
        public async Task<IResult> getABook([Required] int id)
        {
            try
            {
                foreach (Book book in books)
                {
                    if (book.id.Equals(id))
                    {
                        return Results.Ok(book);
                    }
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/books")]
        public async Task<IResult> getAllBooks()
        {
            try
            {
                if (books.Count() != 0)
                {
                    return Results.Ok(books);
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
        public async Task<IResult> updateABook([Required] int id)
        {
            try
            {
                foreach (Book book in books)
                {
                    if (book.id.Equals(id))
                    {
                        book.title = "updated";
                        return Results.Ok(book);
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
        public async Task<IResult> DeleteABook([Required] int id)
        {
            try
            {
                foreach (Book book in books)
                {
                    if (book.id.Equals(id))
                    {
                        books.Remove(book);
                        return Results.Ok();
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