using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{name}", GetSingleLanguage);
            languages.MapPost("/", CreateLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(IRepository<Language> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetSingleLanguage(IRepository<Language> repository, string name)
        {
            return TypedResults.Ok(repository.Get(name));
        }
        
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateLanguage(IRepository<Language> repository, Language language)
        {
            return TypedResults.Ok(repository.Create(language));
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language> repository, Language language, string name)
        {
            return TypedResults.Ok(repository.Update(name, language));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string name)
        {
            var language1 = repository.Delete(name);
            return TypedResults.Ok(language1);

        }
    }
}
