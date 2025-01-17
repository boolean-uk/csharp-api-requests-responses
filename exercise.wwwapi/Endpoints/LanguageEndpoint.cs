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
            languages.MapGet("/{name}", GetALanguage);
            languages.MapPost("/", CreateALanguage);
            languages.MapPut("/{name}", UpdateALanguage);
            languages.MapDelete("/{name}", DeleteALanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(IRepository<Language> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetALanguage(IRepository<Language> repository, string name)
        {
            var language = repository.Get(name);

            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateALanguage(IRepository<Language> repository, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = repository.Create(language);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateALanguage(IRepository<Language> repository, string name, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = repository.Update(name, language);

            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteALanguage(IRepository<Language> repository, string name)
        {
            var language = repository.Delete(name);

            return TypedResults.Ok(language);
        }
    }
}
