using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {

        public static void ConfigureLanguagesEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapPost("/", PostLanguage);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        public static async Task<IResult> PostLanguage(IRepository repository, Language language)
        {
            return TypedResults.Created("", repository.AddLanguage(language));
        }

        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetLanguage(name));
        }

        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language language)
        {
            return TypedResults.Ok(repository.UpdateLanguage(name, language));
        }

        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            repository.DeleteLanguage(name);
            return TypedResults.Ok();
        }
    }
}
