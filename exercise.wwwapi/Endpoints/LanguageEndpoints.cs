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
        public static IResult AddLanguage(IRepository<Language, string> repository, Language entity)
        {
            Language language = repository.Add(entity);
            return TypedResults.Created($"/languages", language);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(IRepository<Language, string> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GatALanguage(IRepository<Language, string> repository, string name)
        {
            Language language = repository.GetOne(name);
            return language != null ? TypedResults.Ok(language) : TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language, string> repository, string name, Language entity)
        {
            Language language = repository.Update(name, entity);
            return language != null ? TypedResults.Created("$/languages", language) : TypedResults.NotFound();
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language, string> repository, string name)
        {
            Language language = repository.Delete(name);
            return language != null ? TypedResults.Ok(language) : TypedResults.NotFound();
        }
    }
}
