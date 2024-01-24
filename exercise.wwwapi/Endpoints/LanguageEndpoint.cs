using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languagesGroup = app.MapGroup("languages");

            languagesGroup.MapGet("/", GetLanguages);
            languagesGroup.MapPost("/", AddLanguage);
            languagesGroup.MapGet("/{name}", GetLanguages);
            languagesGroup.MapPut("/{name}", UpdateLanguages);
            languagesGroup.MapDelete("/{name}", DeleteLanguages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.GetLangs());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, Language language)
        {
            return TypedResults.Ok(repository.AddLang(language));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetLang(name));
        }
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> UpdateLanguages(ILanguageRepository repository, string name, Language language)
        {
            return TypedResults.Ok(repository.UpdateLang(name, language));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> DeleteLanguages(ILanguageRepository repository, string name)
        {
            return TypedResults.Ok(repository.DeleteLang(name));
        }

    }
}
