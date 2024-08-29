using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapPost("/", CreateLanguage);
            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{name}", GetALanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateLanguage(IRepository<Language> repository, Language language)
        {
            var result = repository.Create(language);
            return TypedResults.Created($"http://localhost:5115/languages/{result.name}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(IRepository<Language> repository)
        {
            var result = repository.GetAll();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetALanguage(IRepository<Language> repository, string name)
        {
            var result = repository.Get(name);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language> repository, Language language, string name)
        {
            var result = repository.Update(language, name);
            return TypedResults.Created($"http://localhost:5115/languages/{result.name}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string name)
        {
            var result = repository.Delete(name);
            return TypedResults.Ok(result);
        }
    }
}
