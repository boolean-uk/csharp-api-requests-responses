using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class LanguageEndpoints
    {

        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetAll);
            languages.MapPost("/", Add);
            languages.MapGet("/{name}", GetOne);
            languages.MapDelete("/{name}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Language> repository)
        {
            var languageRepository = repository.GetAll();
            return TypedResults.Ok(languageRepository);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetOne(IRepository<Language> repository, string name)
        {
            var language = repository.GetOne(name);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static Created<Language> Add(IRepository<Language> repository, Language language)
        {
            repository.Add(language);
            return TypedResults.Created($"/{language.Name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Language> repository, string name)
        {
            var language = repository.Delete(name);
            return Results.Ok(language);
        }
    }
}
