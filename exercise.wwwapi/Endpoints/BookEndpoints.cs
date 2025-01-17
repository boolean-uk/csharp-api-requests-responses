using System;
using exercise.wwwapi.Extensions;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        

        public static void ConfigureBookEndPoints(this WebApplication app)
        {
            var languages = app.MapGroup("books");
            languages.MapGet("/", GetBooks);
            languages.MapPost("/", CreateBook);
            languages.MapGet("/{name}", GetBook);
            languages.MapPut("/{name}", UpdateBook);
            languages.MapDelete("/{name}", DeleteBook);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IBookRepository repo, string name)
        {
            var b = repo.DeleteBook(name);
            if (b != null)
                return TypedResults.Ok(b);
            return TypedResults.NotFound(false);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IBookRepository repo, string name)
        {
            var book = repo.GetBook(name);
            if (book != null)
                return TypedResults.Ok(book);
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateBook(HttpContext context, IBookRepository repo, string name, BookView dto)
        {
            var book = repo.UpdateBook(name, dto);
            if (book != null)
                return TypedResults.Created(context.Get_endpointUrl(book.title),book);
            return TypedResults.BadRequest();
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(HttpContext context,IBookRepository repo, BookView dto)
        {
            var book = repo.AddBook(dto);

            if (book != null)
                return TypedResults.Created(context.Get_endpointUrl(book.title), book);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repo)
        {
            return TypedResults.Ok(repo.GetBooks());
        }
    }
}
