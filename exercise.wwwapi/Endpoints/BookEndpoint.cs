using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("Book");

            studentGroup.MapGet("/", GetBooks);
            studentGroup.MapGet("/{id}", GetBook);
            studentGroup.MapPost("/", CreateBook);
            studentGroup.MapPut("/{id}", UpdateBook);
            studentGroup.MapDelete("/{id}", DeleteBook);
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
        public static async Task<IResult> CreateBook(IRepository repository, Book book)
        {
            return TypedResults.Created("", repository.CreateBook(book));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, Book newBook)
        {
            return TypedResults.Ok(repository.UpdateBook(id, newBook));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }
    }
}
