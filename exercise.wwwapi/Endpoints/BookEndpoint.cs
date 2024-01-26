using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapPost("/", AddBook);
            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBookById(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository repository, BookCreate book)
        {
            Book result = repository.InsertBook(book);
            return TypedResults.Created($"{result.Title}", result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, BookCreate book)
        {
            Book result = repository.UpdateBook(id, book);
            return TypedResults.Created($"{result.Title}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }
    }
}
