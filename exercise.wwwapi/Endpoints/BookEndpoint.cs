using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetAllBooks);
            books.MapGet("/{name}", GetABook);
            books.MapPost("/", CreateABook);
            books.MapPut("/{name}", UpdateABook);
            books.MapDelete("/{name}", DeleteABook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(BookRepository repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetABook(BookRepository repository, int id)
        {
            var book = repository.Get(id);

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateABook(BookRepository repository, Book book)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.Data = repository.Create(book);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateABook(BookRepository repository, int id, Book book)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.Data = repository.Update(id, book);

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteABook(BookRepository repository, int id)
        {
            var book = repository.Delete(id);

            return TypedResults.Ok(book);
        }
    }
}
