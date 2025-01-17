using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ConfigureBookEndpoints
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("books");

            counters.MapGet("/", GetBooks);
            counters.MapGet("/{id}", GetBook);
            counters.MapPost("/", PostBook);
            counters.MapPut("/{id}", PutBook);
            counters.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IGuidRepository<Book> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IGuidRepository<Book> repository, Guid id)
        {
            try
            {
                return TypedResults.Ok(repository.Get(id));
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PostBook(IGuidRepository<Book> repository, BookPost entity)
        {
            Book book = repository.Add(new Book { Author = entity.Author, Title = entity.Title, Genre = entity.Genre, NumPages = entity.numPages });
            return TypedResults.Created("", book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutBook(IGuidRepository<Book> repository, Guid id, BookPut entity) 
        {
            Book book = repository.Update(id, new Book { Author = entity.Author, Title = entity.Title, Genre = entity.Genre, NumPages = entity.numPages ?? -1 });
            return TypedResults.Created("", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IGuidRepository<Book> repository, Guid id)
        {
            try
            {
                Book book = repository.Get(id);
                return TypedResults.Ok(new { Deleted = repository.Delete(id), Name = $"{book.Author} - {book.Title}" });
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
