using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapPost("/", CreateBook);
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetABook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IBookRepository repository, BookPayload book)
        {
            var result = repository.Create(book);
            return TypedResults.Created($"http://localhost:5115/books/{result.id}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBookRepository repository)
        {
            var result = repository.GetAll();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetABook(IBookRepository repository, int id)
        {
            var result = repository.Get(id);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IBookRepository repository, BookPayload book, int id)
        {
            var result = repository.Update(book, id);
            return TypedResults.Created($"http://localhost:5115/books/{result.id}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IBookRepository repository, int id)
        {
            var result = repository.Delete(id);
            return TypedResults.Ok(result);
        }
    }
}
