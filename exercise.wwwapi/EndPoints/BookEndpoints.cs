using System;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints;

public static class BookEndpoints
{
    public static void ConfigureBookEndpoint(this WebApplication app)
    {
        var book = app.MapGroup("books");

        book.MapGet("/", GetAllBooks);
        book.MapGet("/{id}", GetBook);
        book.MapPost("/", CreateBook);
        book.MapPatch("/{id}", UpdateBook);
        book.MapDelete("/{id}", DeleteBook);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetAllBooks(IBookRepository repo)
    {
        return TypedResults.Ok(repo.GetBooks());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetBook(IBookRepository repo, int id)
    {
        Book result = repo.GetBook(id);

        if (result == null)
        {
            return TypedResults.NotFound(id);
        }

        return TypedResults.Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public static async Task<IResult> CreateBook(IBookRepository repo, Book book)
    {
        Book result = repo.AddBook(book);
        if (result == null)
        {
            return TypedResults.Conflict($"book already exists!");
        }

        return TypedResults.Created(result.Title);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> UpdateBook(IBookRepository repo, int id, Book book)
    {
        Book result = repo.UpdateBook(id, book);

        if (result == null)
        {
            return TypedResults.NotFound(book.Title);
        }

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> DeleteBook(IBookRepository repo, int id)
    {
        Book result = repo.DeleteBook(id);

        if (result == null)
        {
            return TypedResults.NotFound($"Book was not found");
        }

        return TypedResults.Ok(result);
    }
}
