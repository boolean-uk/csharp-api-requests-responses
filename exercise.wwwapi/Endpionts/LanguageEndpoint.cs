
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpionts
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication application)
        {
            var languageGroup = application.MapGroup("languages");
            languageGroup.MapGet("/", GetAllLanguages);
            languageGroup.MapGet("/{name}", GetALanguage);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapPut("/{name}", UppdateLanguage);
            languageGroup.MapDelete("/{name}", RemoveLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetALanguage(ILanguagesRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetALanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(ILanguagesRepository repository)
        {
            return TypedResults.Ok(repository.GetAllLanguages());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(ILanguagesRepository repository, string name)
        {
            return TypedResults.Ok(repository.AddLanguage(name));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UppdateLanguage(ILanguagesRepository repository, string name, string newName)
        {
            return TypedResults.Ok(repository.UppdageLanguage(name, newName));
        }

        public static IResult RemoveLanguage(ILanguagesRepository repository, string name)
        {
            return TypedResults.Ok(repository.RemoveLanguage(name));
        }
    }
}
