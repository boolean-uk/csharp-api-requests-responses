using exercise.wwwapi.Repository;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void LanguageLogics(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapGet("/", GetAllLanguages);
            languageGroup.MapGet("/{id}", GetLanguage);
            languageGroup.MapPost("/", CreateLanguage);
            languageGroup.MapPost("/{id}", UpdateLanguage);
            languageGroup.MapDelete("/{id}", DeleteLanguage);
        }

        public static IResult GetAllLanguages(ILanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetAllLang());
        }

        public static IResult GetLanguage(ILanguageRepository languages, int id)
        {
            Language? language = languages.GetLanguage(id);
            if (language == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(languages.GetLanguage(id));
        }

        public static IResult CreateLanguage(ILanguageRepository languages, LanguagePostPayload createdLanguage)
        {
            Language? newLanguage = languages.AddLanguage(createdLanguage.name);
            if (newLanguage == null)
                return Results.NotFound("Could not create language");

            return TypedResults.Created($"/students{newLanguage.GetName()}", newLanguage);
        }

        public static IResult UpdateLanguage(ILanguageRepository languages, LanguageUpdatePayload posted, int id)
        {
            Language? language = languages.GetLanguage(id);
            if (language == null)
                return Results.NotFound("ID out of scope");

            language = languages.UpdateLanguage(language, posted);
            return TypedResults.Created($"/students{language.GetName()}", language);
        }

        public static IResult DeleteLanguage(ILanguageRepository languages, int id)
        {
            Language? language = languages.GetLanguage(id);
            if (language == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(languages.DeleteLanguage(id));
        }
    }
}
