using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLaguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("language");

            languageGroup.MapGet("/languages", GetLanguages);
            languageGroup.MapGet("/languages/{name}", GetLanguage);
            languageGroup.MapPut("/languages/{name}", UpdateLanguage);
            languageGroup.MapDelete("/languages/{name}", DeleteLanguage);
            languageGroup.MapPost("/languages/{name}", CreateLanguage);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string FirstName)
        {
            return TypedResults.Ok(repository.GetLanguage(FirstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string language, string NewLanguage)
        {
            return TypedResults.Ok(repository.UpdateLanguage(language, NewLanguage));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string language)
        {
            return TypedResults.Ok(repository.DeleteLanguage(language));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateLanguage(IRepository repository, string language)
        {
            return TypedResults.Ok(repository.CreateLanguage(language));
        }
    }
}
