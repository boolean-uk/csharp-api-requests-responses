
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapPost("/", CreateLanguage);
            languageGroup.MapGet("/", AllLanguages);
            languageGroup.MapGet("/{name}", Language);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        private static async Task<IResult> CreateLanguage(IRepository repository, Language language)
        {
            repository.AddLanguage(language);
            return TypedResults.Created(language.GetName(), language);
        }
        private static async Task<IResult> AllLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }
        private static async Task<IResult> Language(IRepository repository, string name)
        {
            Language language = repository.GetLanguage(name);

            return TypedResults.Ok(language);
        }
        private static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language language)
        {
            repository.UpdateLanguage(name, language);
            return TypedResults.Ok(language);
        }
        private static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            Language language = repository.GetLanguage(name);
            repository.DeleteLanguage(name);
            return TypedResults.Ok(language);
        }
    }
}
