using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Core.Endpoints
{
    public static class LanguagesEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("languages");

            students.MapGet("/", GetLanguages);
            students.MapGet("/{name}", GetSingleLanguage);
            students.MapPost("/", AddLanguage);
            students.MapPut("/{name}", UpdateLanguage);
            students.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            var languages = repository.GetLanguages();
            return Results.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetSingleLanguage(ILanguageRepository repository, string name)
        {
            var language = repository.GetSingleLanguage(name);
            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, Language language)
        {
            var addedLanguage = repository.AddLanguage(language);
            return Results.Created($"https://localhost:7068/languages/{addedLanguage.name}", addedLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, Language updatedLanguage)
        {
            var result = repository.UpdateLanguage(name, updatedLanguage);
            return Results.Created($"https://localhost:7068/languages/{updatedLanguage.name}", updatedLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            var deletedLanguage = repository.DeleteLanguage(name);

            return Results.Ok(deletedLanguage);
        }
    }
}
