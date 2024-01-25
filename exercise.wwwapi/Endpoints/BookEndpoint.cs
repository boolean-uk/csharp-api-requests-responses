using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEnpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapGet("/", GetAllBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPost("/", AddBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IBookRepository<Book> repository)
        {
            return TypedResults.Ok(repository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IBookRepository<Book> repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository<Book> repository, Book book)
        {
            if (book == null)
            {
                return Results.NotFound();
            }
            repository.AddBook(book);
            return TypedResults.Created($"/{book.Id}", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook(IBookRepository<Book> repository, int id, Book book)
        {
            return TypedResults.Ok(repository.UpdateBook(id, book));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IBookRepository<Book> repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }
    }
}
