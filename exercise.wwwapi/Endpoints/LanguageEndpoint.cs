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
            languages.MapPost("/", CreateALanguage);
            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{name}", GetALanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateALanguage(ILanguageRepository repository, Language language)
        {
            var result = repository.CreateALanguage(language);
            return result != null ? TypedResults.Created($"https://localhost:7068/languages", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(ILanguageRepository repository) 
        {
            return TypedResults.Ok(repository.GetAllLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetALanguage(ILanguageRepository repository, string name)
        {
            if (repository.GetALanguage(name) != null)
            {
                return TypedResults.Ok(repository.GetALanguage(name));
            }
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateLanguage(ILanguageRepository repository, string name, string newName)
        {
            
            if (repository.GetALanguage(name) != null)
            {
                var result = repository.UpdateLanguage(name, newName);
                return result != null ? TypedResults.Created($"https://localhost:7068/languages", result) : TypedResults.BadRequest();
            }
            return TypedResults.NotFound();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteLanguage(ILanguageRepository repository, string name)
        {
            if (repository.GetALanguage(name) != null)
            {
                return TypedResults.Ok(repository.DeleteLanguage(name));
            }
            return TypedResults.NotFound();

        }


    }
}
