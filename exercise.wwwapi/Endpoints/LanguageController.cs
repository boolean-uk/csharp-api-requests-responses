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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult DeleteLanguage(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.DeleteLanguage(name));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult UpdateLanguage(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.UpdateLanguage(new Models.Language(name)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult AddLanguage(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.AddLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult GetLanguages(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult GetLanguage(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetLanguage(name));

        }
    }
}
