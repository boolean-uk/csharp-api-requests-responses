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
            languageGroup.MapPost("/", CreateLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        public static IResult GetAll(ILanguageRepository languages)
        {
            return TypedResults.Ok(languages.GetAllLanguages());
        }

        public static IResult GetLanguage(ILanguageRepository languages, string name)
        {
            return TypedResults.Ok(languages.GetLanguage(name));
        }
        public static IResult CreateLanguage(ILanguageRepository languages, LanguagePostPayload newLanData)
        {
            Language newLanguage = languages.AddLanguage(newLanData.Name);
            return TypedResults.Created($"/languages {newLanguage.Id}", newLanguage);
        }

        public static IResult UpdateLanguage(ILanguageRepository languages, string name, LanguageUpdatePayload updateLanguage)
        {
            try
            {
                Language? language = languages.UpdateLanguage(name, updateLanguage);
                if (language == null)
                {
                    return Results.NotFound($"Student with name {name} is not found");
                }
                return TypedResults.Ok(language);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        public static IResult DeleteLanguage(ILanguageRepository languages, string name)
        {
            Language language = languages.DeleteLanguage(name);
            if (language == null)
            {
                return Results.NotFound($"Language name {name} not found");
            }
            return TypedResults.Ok(languages.DeleteLanguage(name));
        }

    }
}