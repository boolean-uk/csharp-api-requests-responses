namespace exercise.wwwapi.Endpoints;

using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;

public static class BookEndpoint
{
    public static void ConfigureBookEndpoint(this WebApplication app)
    {
        var books = app.MapGroup("books");
        books.MapGet("/", GetAll);
        books.MapPost("/", Create);
        books.MapGet("/{id}", Get);
        books.MapPut("/update/{id}", Update);
        books.MapDelete("/{id}", Delete);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetAll(IRepository<Book, BookViewModel> repository)
    {
        return Results.Ok(repository.GetAll());
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    public static async Task<IResult> Create(
        IRepository<Book, BookViewModel> repo,
        BookViewModel book
    )
    {
        //TODO: add good string
        // All fields required, so no LanguagePost
        var created = repo.Create(book);
        return Results.Created($"{created.id}", created);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> Get(IRepository<Book, BookViewModel> repo, int id)
    {
        return Results.Ok(repo.Get(b => b.id == id));
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> Update(
        IRepository<Book, BookViewModel> repo,
        int id,
        BookViewModel updated
    )
    {
        return Results.Created($"{id}", repo.Update(b => b.id == id, updated));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> Delete(IRepository<Book, BookViewModel> repo, int id)
    {
        return Results.Ok(repo.Delete(b => b.id == id));
    }
}
