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
            books.MapGet("/", GetBooks);
            books.MapGet("/{id}", GetABook);
            books.MapPost("/", AddBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBooks(IRepository<Book> repository)
        {
            Payload<List<Book>> payload = new Payload<List<Book>>();
            payload.data = repository.GetAll();

            return TypedResults.Ok(payload);
        }

        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetABook(IRepository<Book> repository, string id)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.GetOne(id);

            return payload.data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddBook(IRepository<Book> repository, Book book)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Add(book);

            return TypedResults.Ok(payload);
        }

        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IRepository<Book> repository, string id, Book book)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Update(id, book);

            return TypedResults.Ok(payload);
        }

        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IRepository<Book> repository, string id)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Delete(id);

            return TypedResults.Ok(payload);
        }
    }
}
