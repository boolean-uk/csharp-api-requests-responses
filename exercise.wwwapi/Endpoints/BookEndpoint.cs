using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var LanguageGroup = app.MapGroup("books");

            LanguageGroup.MapGet("/", GetAll);
            LanguageGroup.MapGet("/{id}", Get);
            LanguageGroup.MapPost("/", Post);
            LanguageGroup.MapPut("/{id}", Put);
            LanguageGroup.MapDelete("/{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IBookRepository repository)
        {
            return TypedResults.Ok(repository.Get());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IBookRepository repository, int id)
        {
            return TypedResults.Ok(repository.Get(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Post(IBookRepository repository, ExternalBook book)
        {
            return TypedResults.Created("url", repository.Create(book));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> Put(IBookRepository repository, int id, ExternalBook book)
        {
            return TypedResults.Accepted("url", repository.Update(id, book));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> Delete(IBookRepository repository, int id)
        {
            return TypedResults.Accepted("url", repository.Delete(id));
        }
    }
}
