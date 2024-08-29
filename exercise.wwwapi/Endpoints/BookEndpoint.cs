using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetBooks);
            books.MapPost("/", AddBook);
            books.MapGet("/{name}", GetBook);
            books.MapPut("/{name}", UpdateBook);
            books.MapDelete("/", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBooks(IBookRepository repository)
        {
            var result = repository.GetClasses();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddBook(IBookRepository repository, PayLoadBook payload)
        {
            var result = repository.AddClass(payload);
            return TypedResults.Created($"http://localhost:5115/books/{result.id}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBook(IBookRepository repository, int id)
        {
            var result = repository.GetClass(id);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult UpdateBook(IBookRepository repository, PayLoadBook payLoad, int id)
        {
            var result = repository.UpdateClass(payLoad, id);
            return TypedResults.Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IBookRepository repository, int id)
        {
            var result = repository.DeleteClass(id);
            return TypedResults.Ok(result);
        }
    }
}
