using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var booksGroup = app.MapGroup("books");

            booksGroup.MapGet("/", GetBooks);
            booksGroup.MapGet("/{id}", GetBook);
            booksGroup.MapPut("/{id}", PutBook);
            booksGroup.MapPost("/", PostBook);
            booksGroup.MapDelete("/{id}", DeleteBook);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutBook(IRepository repository, int id, InputBook input)
        {
            return TypedResults.Ok(repository.UpdateBook(id, input));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PostBook(IRepository repository, InputBook input)
        {
            return TypedResults.Ok(repository.AddBook(input));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }
    }
}
