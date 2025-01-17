using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("books");

            students.MapPost("/", AddBook);
            students.MapGet("/", GetBooks);
            students.MapGet("/{firstName}", GetBook);
            students.MapPut("/{firstName}", UpdateBook);
            students.MapDelete("/{firstName}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository repository, Book book)
        {
            repository.Add(book);

            //return Results.Ok(student);
            return TypedResults.Created($"https://localhost:7068/students/{book.Title}", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            return Results.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IBookRepository repository, string title)
        {
            return Results.Ok(repository.Get(title));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, string title, Book book)
        {
            repository.Update(title, book);

            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IBookRepository repository, string title)
        {
            repository.Delete(title);

            return Results.Ok();
        }
    }
}
