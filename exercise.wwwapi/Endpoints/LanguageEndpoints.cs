using exercise.wwwapi.Models.Language;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndPoints(this WebApplication app)
        {
            var students = app.MapGroup("/Languages");

            students.MapPost("", AddLanguage);
            students.MapGet("", GetAllLanguages);
            students.MapGet("/{language}", GetALanguage);
            students.MapPatch("/{language}", UpdateLanguage);
            students.MapDelete("/{language}", DeleteStudent);

        }

        public static IResult AddLanguage(ILanguageRepo languages, LanguagePayload payLoad)
        {
            if (payLoad == null) { return Results.BadRequest("Empty payload"); }
            if (string.IsNullOrWhiteSpace(payLoad.languageName)) { return Results.BadRequest("Can't be empty"); }
            Language language = new Language(payLoad.languageName);
            languages.Add(language);
            return TypedResults.Created($"/students/{language.getName()}", language);
        }

        public static IResult GetAllLanguages(IRepository<Language> languages)
        {
            if (languages.GetAll().Count() == 0) return Results.NoContent();

            return TypedResults.Ok(languages.GetAll());
        }

        public static IResult GetALanguage(IRepository<Language> languages, string languageName)
        {
            var language = languages.Get(languageName);
            if (language == null) { return Results.NotFound($"No language with name {languageName} was found"); }
            return TypedResults.Ok(language);
        }

        public static IResult UpdateLanguage(ILanguageRepo languages, string languageName, LanguagePayload updatePayload)
        {
            var language = languages.Update(languageName, updatePayload);
            if (language == null) { return Results.NotFound($"No language with name {languageName} was found"); }
            return TypedResults.Created($"/Languages/{language.getName()}", language);
        }

        public static IResult DeleteStudent(IRepository<Language> languages, string languageName)
        {
            var language = languages.Remove(languageName);
            if (language == null)
            {
                return Results.NotFound($"No language with name {languageName} was found");
            }
            else
            {
                return TypedResults.Ok(language);
            }
        }
    }
}
