using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using exercise.wwwapi.Reposetories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

public static class BookEndpoint
{
    public static void ConfigureBookEndpoint(this WebApplication app)
    {
        var book = app.MapGroup("book");
        book.MapGet("/", GetAllBook);
        book.MapPost("/", CreateNewBook);
        book.MapGet("/{name}", GetBook);
        book.MapPut("/{name}", UpdateBook);
        book.MapDelete("/{name}", DeleteBook);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    public static IResult GetAllBook(IRepository<Book, int> collection)
    {
        return TypedResults.Ok(collection.GetAll());
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult GetBook(IRepository<Book, int> collection, int id)
    {
        var b = collection.GetAll().FirstOrDefault(x => x.Id.Equals(id));
        if (b is null) return TypedResults.NotFound();
        return TypedResults.Ok(b);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    public static IResult CreateNewBook(IRepository<Book, int> collection, PostBook book)
    {
        var b = collection.Create(new Book(book.Title, book.NumPages, book.Author, book.Genre));
        return TypedResults.Created($"/stud{b.Id}", b);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult UpdateBook(IRepository<Book, int> collection, int id, PostBook book)
    {
        var b = collection.GetAll().FirstOrDefault(x => x.Id.Equals(id));
        if (b is null) return TypedResults.NotFound();
        b.Title = book.Title;
        b.NumPages = book.NumPages;
        b.Author = book.Author;
        b.Genre = book.Genre;
        return TypedResults.Ok(b);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult DeleteBook(IRepository<Book, int> collection, int id)
    {
        var b = collection.GetAll().FirstOrDefault(x => x.Id.Equals(id));
        collection.Delete(b);
        return TypedResults.Ok(b);
    }
}