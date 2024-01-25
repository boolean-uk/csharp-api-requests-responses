using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static exercise.wwwapi.Models.Book;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var BookGroup = app.MapGroup("books");

            BookGroup.MapGet("/", GetBooks);
            BookGroup.MapPost("/", AddBook);
            BookGroup.MapGet("/{id}", GetBook);
            BookGroup.MapPut("/{id}", UpdateBook);
            BookGroup.MapDelete("/{id}", DeleteBooks);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository repository, MakeBook make)
        {
            return TypedResults.Ok(repository.AddBook(make));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IBookRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, MakeBook make)
        {
            return TypedResults.Ok(repository.UpdateBook(id, make));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> DeleteBooks(IBookRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }


    }
}
