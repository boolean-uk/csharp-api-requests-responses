using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("book");

            bookGroup.MapGet("/", GetAllBooks);
            bookGroup.MapGet("/{id}", GetABook);
            bookGroup.MapPost("/", CreateBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateBook(IRepository repository, InPuBook book)
        {
            repository.AddBook(book);
            return TypedResults.Created($"https://localhost:7206/students/{book.Title}", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetABook(IRepository repository, int id)
        {
            Book test = repository.GetABook(id);
            if (test == null)
            {
                return Results.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBook());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, InPuBook book)
        {
            Book test = repository.UpdateABook(id, book);
            if (test == null)
            {
                return Results.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            Book test = repository.GetABook(id);
            return test == null ? Results.NotFound($"Id: {id} not found!") : TypedResults.Ok(repository.DeleteABook(id));
        }
    }
}

