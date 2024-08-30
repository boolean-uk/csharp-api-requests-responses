using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("books")]
    public static class BookController
    {
        public static void ConfigureBookController(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAll);
            books.MapGet("/{id}", GetBook);
            books.MapPost("/", AddBook);
            books.MapPut("/", UpdateBook);
            books.MapDelete("/", DeleteBook);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult DeleteBook(IBookRepository repository, int id)
        {
            var result = repository.DeleteBook(id);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult UpdateBook(IBookRepository repository, int id, Book book)
        {
            var result = repository.UpdateBook(id, book);
            //string returnResult = result.Id.ToString() + " " + result.Title + " " + result.numPages.ToString() + " " + result.Author + " " + result.Genre;
            return result == null ? TypedResults.BadRequest(result) : TypedResults.Created();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult AddBook(IBookRepository repository, Book book)
        {
            var result = repository.AddBook(book);
            return result == null ? TypedResults.BadRequest(result) : TypedResults.Created();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetBook(IBookRepository repository, int id)
        {
            var result = repository.GetBook(id);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult GetAll(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }
    }
}
