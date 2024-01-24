
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Models.Payload;

namespace exercise.Endpoints {
    public static class LanguageEndpoint {

        public static void ConfigureLanguageEndpoint(this WebApplication app) {
            var students = app.MapGroup("languages");
            students.MapGet("/", GetAllLanguages);
            students.MapPost("/", CreateLanguage);
            students.MapGet("/{name}", GetLanguage);
            students.MapPut("/{name}", UpdateLanguage);
            students.MapDelete("/{name}", DeleteLanguage);
        }

        public static IResult CreateLanguage(ILanguageRepository sr, LanguagePostPayload payload)
        {
            if (payload == null)
            {
                return Results.BadRequest("Payload cannot be null");
            }

            Language language = sr.AddLanguage(payload.name);
            return TypedResults.Created($"/tasks/{language.Name}", language);
        }

        public static IResult GetAllLanguages(ILanguageRepository sr)
        {
            return TypedResults.Ok(sr.GetAllLanguages());
        }

        public static IResult GetLanguage(ILanguageRepository sr, string Name)
        {
            var language = sr.GetLanguage(Name);

            if (language == null)
            {
                return Results.NotFound($"Language with Name {Name} not found.");
            }

            return TypedResults.Ok(language);
        }

        public static IResult DeleteLanguage(ILanguageRepository sr, string Name)
        {
            var deletedLanguage = sr.DeleteLanguage(Name);

            if (deletedLanguage == null)
            {
                return Results.NotFound($"Language with Name {Name} not found.");
            }

            return TypedResults.Ok(deletedLanguage);
        }

        public static IResult UpdateLanguage(ILanguageRepository lr, string Name, LanguageUpdatePayload payload)
        {
            try
            {
                if (payload == null)
                {
                    return Results.BadRequest("Payload cannot be null");
                }

                Language? language = lr.UpdateLanguage(Name, payload);

                if (language == null)
                {
                    return Results.NotFound($"Language with Name {Name} not found.");
                }

                return Results.Ok(language);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}