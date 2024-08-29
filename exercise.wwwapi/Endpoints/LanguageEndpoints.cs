using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapPost("/", AddLanguage);
            languages.MapGet("/", GetLanguages);
            languages.MapGet("/{name}", GatALanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(IRepository<Language> repository, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = repository.Add(language);
            return TypedResults.Created($"/languages", payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(IRepository<Language> repository)
        {
            Payload<List<Language>> payload = new Payload<List<Language>>();
            payload.Data = repository.GetAll();
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GatALanguage(IRepository<Language> repository, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = repository.GetOne(name);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language> repository, string name, string updatedName)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = repository.Update(name, updatedName);
            return TypedResults.Created("$/languages", payload);
        }


        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = repository.Delete(name);
            return TypedResults.Ok(payload);
        }
    }
}
