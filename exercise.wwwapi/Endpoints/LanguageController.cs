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
        private static IResult DeleteLanguage(ILanguageRepository repository, string name)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult UpdateLanguage(ILanguageRepository repository, string name)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult AddLanguage(ILanguageRepository repository, string name)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult GetLanguages(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult GetLanguage(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetLanguage(name));

        }
    }
}
