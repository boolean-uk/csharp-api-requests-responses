using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAll);
            books.MapGet("/{id}", Get);
            books.MapPost("/", Create);
            books.MapPut("/{id}", Update);
            books.MapDelete("/", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Book> repository)
        {
            Payload<List<Book>> payload = new Payload<List<Book>>();
            payload.data = repository.GetAll();
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Get(IRepository<Book> repository, string id)
        {
            bool intSuccess = int.TryParse(id, out int result);
            if (!intSuccess)
            {
                return TypedResults.BadRequest($"Id {id} given not valid");
            }

            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Get(id);

            if (payload.data == null)
            {
                return TypedResults.NotFound($"Book with id {id} not found.");
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Create(IRepository<Book> repository, Book model)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Add(model);
            if (payload.data == null)
            {
                return TypedResults.BadRequest($"Book with title {model.Title} already exists.");
            }
            return TypedResults.Created($"https://localhost:7068/books/{payload.data.Id}", payload.data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepository<Book> repository, string id, Book model)
        {
            bool intSuccess = int.TryParse(id, out int result);
            if (!intSuccess)
            {
                return TypedResults.BadRequest($"Id {id} given not valid");
            }

            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Update(id, model);
            if (payload.data == null)
            {
                return TypedResults.NotFound($"Book with id {id} not found.");
            }
            return TypedResults.Created($"https://localhost:7068/books/{payload.data.Id}", payload.data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Delete(IRepository<Book> repository, string id)
        {
            bool intSuccess = int.TryParse(id, out int result);
            if (!intSuccess)
            {
                return TypedResults.BadRequest($"Id {id} given not valid");
            }

            Payload<Book> payload = new Payload<Book>();
            payload.data = repository.Delete(id);

            if (payload.data == null)
            {
                return TypedResults.NotFound($"Book with id {id} not found.");
            }

            return TypedResults.Ok(payload);
        }
    }
}
