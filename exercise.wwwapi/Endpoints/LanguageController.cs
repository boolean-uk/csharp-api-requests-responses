using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("languages")]
    public static class LanguageController
    {
        public static void ConfigureLanguageController(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/{id}", GetLanguage);
            languages.MapGet("/", GetLanguages);
            languages.MapPost("/", AddLanguage);
            languages.MapPut("/", UpdateLanguage);
            languages.MapDelete("/", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteLanguage(ILanguageRepository repository, string name)
        {
            var result = repository.DeleteLanguage(name);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateLanguage(ILanguageRepository repository, string name, string newName)
        {
            var result = repository.UpdateLanguage(name, newName);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddLanguage(ILanguageRepository repository, string name)
        {
            var result = repository.AddLanguage(name);
            return result == null ? TypedResults.BadRequest(result) : TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetLanguage(ILanguageRepository repository, string name)
        {
            var result = repository.GetLanguage(name);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);
        }
    }
}
