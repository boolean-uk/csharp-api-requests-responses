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
            languages.MapPost("/", AddLanguage);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(IRepository<Language> repository)
        {
            Payload<List<Language>> payload = new Payload<List<Language>>();
            payload.data = repository.GetClasses();
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(IRepository<Language> repository, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.AddClass(language);
            return TypedResults.Created($"http://localhost:5115/languages/{payload.data.name}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguage(IRepository<Language> repository, string firstName)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.GetClass(firstName);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult UpdateLanguage(IRepository<Language> repository, Language newLanguage, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.UpdateClass(newLanguage, name);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.DeleteClass(name);
            return TypedResults.Ok(payload);
        }
    }
}

