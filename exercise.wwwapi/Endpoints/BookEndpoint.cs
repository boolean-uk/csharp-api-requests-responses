using System;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.View;

namespace exercise.wwwapi.Endpoints;

public static class BookEndpoint
{
    public static void ConfigureBookEndpoint(this WebApplication app)
    {
        var books = app.MapGroup("books");

        books.MapGet("/", GetBooks);
        books.MapPost("/", AddBook);
        books.MapGet("/{id}", GetBook);
        books.MapDelete("/{id}", DeleteBook);
        books.MapPut("/{id}", UpdateBook);
    }

    public static async Task<IResult> GetBooks(IBookRepository repository)
    {
        var books = repository.GetBooks();
        return Results.Ok(books);
    }

    public static async Task<IResult> GetBook(IBookRepository repository, int id)
    {
        var book = repository.GetBook(id);
        if (book == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(book);
    }

    public static async Task<IResult> AddBook(IBookRepository repository, BookPost book)
    {
        var newBook = repository.AddBook(new Book() { Title = book.Title, NumPages = book.Pages, Author = book.Author, Genre = book.Genre});
        return Results.Created($"/books/{newBook.Id}", newBook);
    }

    public static async Task<IResult> UpdateBook(IBookRepository repository, int id, BookPut book)
    {
        var updatedBook = repository.UpdateBook(id, new Book() {Id = id, Title = book.Title, NumPages = (int)book.Pages, Author = book.Author, Genre = book.Genre });
        if (updatedBook == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(updatedBook);
    }

    public static async Task<IResult> DeleteBook(IBookRepository repository, int id)
    {
        var result = repository.DeleteBook(id);
        if (!result)
        {
            return Results.NotFound();
        }
        return Results.NoContent();
    }
}
