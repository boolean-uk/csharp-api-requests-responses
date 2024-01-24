using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var LanguageGroup = app.MapGroup("languages");

            LanguageGroup.MapGet("/", GetAll);
            LanguageGroup.MapGet("/{name}", Get);
            LanguageGroup.MapPost("/", Post);
            LanguageGroup.MapPut("/{name}", Put);
            LanguageGroup.MapDelete("/{name}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.Get());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.Get(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Post(ILanguageRepository repository, Language language)
        {
            return TypedResults.Created("url", repository.Create(language));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> Put(ILanguageRepository repository, string name, Language language)
        {
            return TypedResults.Accepted("url", repository.Update(name, language));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> Delete(ILanguageRepository repository, string name)
        {
            return TypedResults.Accepted("url", repository.Delete(name));
        }
    }
}
