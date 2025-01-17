using System.Reflection;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoint
    {
        public static void ConfigureBooksEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapPost("/", BookCreate);
            books.MapGet("/{id}", BookGet);
            books.MapGet("/", BookGetAll);
            books.MapPut("/{id}", BookUpdate);
            books.MapDelete("/{id}", BookDelete);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> BookGetAll(BooksRepository repository)
        {
            var books = repository.GetAll();
            return Results.Ok(books);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> BookGet(BooksRepository repository, int id)
        {
            var book = repository.Get(id);
            return Results.Ok(book);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> BookCreate(BooksRepository repository, BookPost entity)

        {
            var book = new Book();
            book.Title = entity.Title;
            book.numPages = entity.numPages;
            book.author = entity.author;
            book.genre = entity.genre;

            repository.Add(book);
            return Results.Ok(repository.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> BookUpdate(BooksRepository repository, int id, BooksPut entity)

        {
            try
            {
                repository.Uppdate(id, entity.Title, entity.numPages, entity.author, entity.genre);
                return Results.Ok(repository.GetAll());
            }
            catch (Exception ex)
            {
                {
                    return TypedResults.Problem(ex.Message);
                }

            }

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> BookDelete(BooksRepository repository, int id)

        {
            try
            {
                if (repository.Get(id)== null)
                {
                    repository.Delete(id);
                    return Results.Ok(repository.GetAll());
                }
                return Results.NotFound();
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }

        }
    }
}
