using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPut("{name}", UpdateLanguage);
            languageGroup.MapDelete("{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetLanguageById(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, Language language)
        {
            Language result = repository.InsertLanguage(language);
            return TypedResults.Created($"{language.Name}", result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language language)
        {
            Language result = repository.UpdateLanguage(name, language);
            return TypedResults.Created($"{language.Name}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.DeleteLanguage(name));
        }
    }

}
