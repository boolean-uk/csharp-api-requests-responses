
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

        private static async Task<IResult> CreateLanguage(IRepository<Language> repository, Language language)
        {
            repository.Add(language);
            return TypedResults.Created(language.GetName(), language);
        }
        private static async Task<IResult> AllLanguages(IRepository<Language> repository)
        {
            return TypedResults.Ok(repository.Get());
        }
        private static async Task<IResult> Language(IRepository<Language> repository, string name)
        {
            Language language = repository.GetById(name);

            return TypedResults.Ok(language);
        }
        private static async Task<IResult> UpdateLanguage(IRepository<Language> repository, string name, Language language)
        {
            repository.Update(name, language);
            return TypedResults.Ok(language);
        }
        private static async Task<IResult> DeleteLanguage(IRepository<Language> repository, string name)
        {
            Language language = repository.GetById(name);
            repository.Delete(name);
            return TypedResults.Ok(language);
        }
    }
}
