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
            languages.MapGet("/", GetLanguages);
            languages.MapGet("/{name}", GetALanguage);
            languages.MapPost("/", AddLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(IRepository<Language> repository)
        {
            Payload<List<Language>> payload = new Payload<List<Language>>();
            payload.data = repository.GetAll();

            return TypedResults.Ok(payload);
        }

        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetALanguage(IRepository<Language> repository, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.GetOne(name);

            return payload.data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(IRepository<Language> repository, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.Add(language);

            return TypedResults.Ok(payload);
        }

        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language> repository, string name, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.Update(name, language);

            return TypedResults.Ok(payload);
        }

        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.Delete(name);

            return TypedResults.Ok(payload);
        }
    }
}
