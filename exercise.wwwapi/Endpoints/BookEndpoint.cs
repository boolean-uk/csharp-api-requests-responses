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

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository repository, BookPost book)
        {
            var newBook = repository.AddBook(book);
            return TypedResults.Created($"{newBook.Id}", newBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            var book = repository.GetBook(id);

            if (book == null)
            {
                return TypedResults.NotFound($"Book with id {id} was not found");
            }

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, BookPost book)
        {
            var updatedBook = repository.UpdateBook(id, book);

            if (updatedBook == null)
            {
                return TypedResults.NotFound($"Book with id {id} was not found");
            }

            return TypedResults.Created($"{id}", updatedBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            var book = repository.DeleteBook(id);

            if (book == null)
            {
                return TypedResults.NotFound($"Book with id {id} was not found");
            }

            return TypedResults.Ok(book);
        }
    }
}
