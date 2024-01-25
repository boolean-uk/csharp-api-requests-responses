using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var BookGroup = app.MapGroup("books");

            BookGroup.MapGet("/", GetBooks);
            BookGroup.MapGet("/{id}", GetBook);
            BookGroup.MapPost("/", CreateBook);
            BookGroup.MapPut("/{id}", UpdateBook);
            BookGroup.MapDelete("/", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateBook(IBookRepository repository, Book book)
        {
            if (!book.Title.Any() || !book.Author.Any() || !book.Genre.Any())
            {
                return Results.BadRequest("Missing some data");
            }
            repository.AddBook(book);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IBookRepository repository, int id)
        {
            var book = repository.GetBooks().FirstOrDefault(s => s.Id == id);

            if (book != null) return TypedResults.Ok(book);
            return Results.NotFound($"Book: {id} not found!");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, Book newBook)
        {
            var book = repository.GetBooks().First(s => s.Id == id);

            if (book == null) return Results.NotFound($"Book: {id} not found!");
            if (!book.Title.Any() || !book.Author.Any() || !book.Genre.Any())
            {
                return Results.BadRequest("Missing some data");
            }

            book.Update(newBook.Title, newBook.NumPages, newBook.Author, newBook.Genre);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {
            var book = repository.GetBooks().First(s => s.Id == id);

            if (book == null) return Results.NotFound($"Book: {id} not found!");

            repository.DeleteBook(book);
            return TypedResults.Ok(book);

        }
    }
}
