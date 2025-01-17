using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapPost("/", AddLanguages);
            languages.MapGet("/", GetLanguages);
            languages.MapGet("/{name}", GetALanguage);
            languages.MapPut("/{name}", UpdateALanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddLanguages(IRepository<Language> repository, Language language)
        {
            Payload<Language> payload = new();
            payload.data = repository.AddEntity(language);
            return payload.data != null ? TypedResults.Created($"https://localhost:7068/{language.name}", payload.data) : TypedResults.BadRequest();
        }
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(IRepository<Language> repository)
        {
            Payload<List<Language>> payload = new();
            payload.data = repository.GetEntities();
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetALanguage(IRepository<Language> repository, string firstName)
        {
            Payload<Language> payload = new();
            payload.data = repository.GetAEntity(firstName);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult UpdateALanguage(IRepository<Language> repository, Language language, string firstName)
        {
            Payload<Language> payload = new();
            payload.data = repository.ChangeAnEntity(language, firstName);
            return payload.data != null ? TypedResults.Created($"https://localhost:7068/{firstName}", payload.data) : TypedResults.BadRequest();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string firstName)
        {
            Payload<string> payload = new();
            payload.data = repository.DeleteAnEntity(firstName);
            return payload.data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
        }

    }
}

