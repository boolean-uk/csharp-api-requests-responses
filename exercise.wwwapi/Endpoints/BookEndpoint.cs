using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

public static class BookEndpoint
{
    public static void ConfigureBookEndpoint(this WebApplication app)
    {
        var studentGroup = app.MapGroup("books");

        studentGroup.MapPost("/create/", CreateBook);
        studentGroup.MapGet("/", GetBooks);
        studentGroup.MapGet("/{id}", GetBook);
        studentGroup.MapPut("/{id}", UpdateBook);
        studentGroup.MapDelete("/{id}", DeleteBook);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    public static async Task<IResult> CreateBook(IBookRepository repository, Book book)
    {
        var newBook = repository.AddBook(book);
        return TypedResults.Created($"/{newBook.Id}", newBook);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetBooks(IBookRepository repository)
    {
        return TypedResults.Ok(repository.GetBooks());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetBook(IBookRepository repository, int id)
    {
        var book = repository.GetBooks().FirstOrDefault(x => x.Id == id);

        if (book == null)
        {
            return Results.NotFound($"Id: {id} not found!");
        }

        return TypedResults.Ok(book);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> UpdateBook(IBookRepository repository, int id, Book book)
    {
        var toEdit = repository.GetBooks().FirstOrDefault(x => x.Id == id);

        if (toEdit == null)
        {
            return Results.NotFound($"Id: {id} not found!");
        }

        toEdit.Title = book.Title;
        toEdit.NumPages = book.NumPages;
        toEdit.Author = book.Author;
        toEdit.Genre = book.Genre;
        return TypedResults.Ok(toEdit);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> DeleteBook(IBookRepository repository, int id)
    {
        var Deleted = repository.DeleteBook(id);

        if (Deleted == null)
        {
            return Results.NotFound($"Id: {id} not found!");
        }

        return TypedResults.Ok(Deleted);
    }
}
