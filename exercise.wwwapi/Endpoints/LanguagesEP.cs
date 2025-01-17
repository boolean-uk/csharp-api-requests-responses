using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguagesEP
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPost("/", AddLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(ILanguage languages, Language language)
        {

            return TypedResults.Created($"/languages/{language.Name}" ,languages.AddLanguage(language));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(ILanguage languages)
        {
            return Results.Ok(languages.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(ILanguage languages, string name)
        {
            return Results.Ok(languages.GetLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(ILanguage languages, string name, Language language)
        {
            return TypedResults.Created($"/languages/{language.Name}" ,languages.UpdateLanguage(language, name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(ILanguage languages, string name)
        {
            return Results.Ok(languages.DeleteLanguage(name));
        }

    }
}
