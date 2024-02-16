using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("/languages");
            languageGroup.MapGet("/", GetAll);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        public static IResult GetAll(ILanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetLanguages());
        }

        public static IResult GetLanguage(ILanguageRepository languages, string name)
        {
            Language language = languages.GetLanguage(name);
            if (language == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(language);
        }

        public static IResult AddLanguage(ILanguageRepository languages, LanguageCreatePayload languageData)
        {
            Language language = languages.AddLanguage(languageData);
            return TypedResults.Created($"/languages/{language.Name}", language);
        }

        public static IResult UpdateLanguage(ILanguageRepository languages, string name, LanguageUpdatePayload languageData)
        {
            Language language = languages.UpdateLanguage(name, languageData);
            if (language == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(language);
        }

        public static IResult DeleteLanguage(ILanguageRepository languages, string name)
        {
            Language language = languages.DeleteLanguage(name);
            if (language == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok();
        }
    }
}
