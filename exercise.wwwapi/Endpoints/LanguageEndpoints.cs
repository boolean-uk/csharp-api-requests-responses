using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("languages");
            taskGroup.MapGet("/", GetAllLanguages);
            taskGroup.MapPost("/", CreateLanguage);
            taskGroup.MapGet("/{name}", GetALanguage);
            taskGroup.MapPut("/{name}", UpdateLanguage);
            taskGroup.MapDelete("/{name}", DeleteLanguage);
        }

        public static IResult GetAllLanguages(ILanguageRepository language)
        {
            return TypedResults.Ok(language.GetAllLanguages());
        }
        public static IResult CreateLanguage(ILanguageRepository language, LanguagePostPayload data)
        {
            return TypedResults.Created("", language.AddLanguage(data));
        }

        public static IResult GetALanguage(ILanguageRepository language, string name)
        {
            Language? result = language.GetLanguage(name);
            if (result is null) return TypedResults.NotFound();
            return TypedResults.Ok(result);
        }

        public static IResult UpdateLanguage(ILanguageRepository language, string name, LanguagePostPayload data)
        {
            try
            {
                Language result = language.ChangeLanguage(name, data);
                return Results.Created("", result);
            }
            catch
            {
                return Results.NotFound();
            }
        }
        public static IResult DeleteLanguage(ILanguageRepository language, string name)
        {
            try
            {
                Language result = language.DeleteLanguage(name);
                return TypedResults.Ok(result);
            }
            catch
            {
                return Results.NotFound();
            }
        }
    }
}
