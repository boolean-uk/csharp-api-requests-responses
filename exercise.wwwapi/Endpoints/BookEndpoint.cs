using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("Books");
            books.MapPost("/", AddBooks);
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetABook);
            books.MapPut("/{id}", UpdateABook);
            books.MapDelete("/{id}", DeleteABook);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddBooks(IRepository<Book> repository, Book book)
        {
            Payload<Book> payload = new();

            payload.data = repository.AddEntity(book);
            return payload.data != null ? TypedResults.Created($"https://localhost:7068/{book.title}", payload.data) : TypedResults.BadRequest();

        }
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static IResult GetAllBooks(IRepository<Book> repository)
        {
            Payload<List<Book>> payload = new();
            payload.data = repository.GetEntities();
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetABook(IRepository<Book> repository, int id)
        {
            Payload<Book> payload = new();
            payload.data = repository.GetAEntity($"{id}");
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]

        public static IResult UpdateABook(IRepository<Book> repository, Book book, int id)
        {
            Payload<Book> payload = new();
            payload.data = repository.ChangeAnEntity(book, $"{id}");
            return TypedResults.Created($"https://localhost:7068/{id}", payload.data);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteABook(IRepository<Book> repository, int id)
        {
            Payload<string> payload = new();
           
            payload.data = repository.DeleteAnEntity(id.ToString());
            return TypedResults.Ok(payload);
        }
    }
}
