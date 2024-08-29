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
            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPost("/", CreateLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(IRepository<Language, string> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateLanguage(IRepository<Language, string> repository, Language language)
        {
            Language l = repository.Add(language);
            return TypedResults.Created("/", l);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetLanguage(IRepository<Language, string> repository, string name)
        {
            Language l = repository.Get(name);
            return l != null ? TypedResults.Ok(l) : TypedResults.NotFound($"Language: {name} was not found");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateLanguage(IRepository<Language, string> repository, string name, Language language)
        {
            Language l = repository.Update(name, language);
            return l != null ? TypedResults.Created("/", l) : TypedResults.NotFound($"Language: {name} was not found");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteLanguage(IRepository<Language, string> repository, string name)
        {
            Language l = repository.Delete(name);
            return l != null ? TypedResults.Ok(l) : TypedResults.NotFound($"Language: {name} was not found");
        }
    }
}
