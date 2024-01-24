using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.EndPoints
{
    public static class LanguageEndPoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapGet("/", GetAllLanguages);
            languageGroup.MapGet("/{name}", GetLanguageByName);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguageByName);
        }

        public static IResult AddLanguage(Language language, LanguageCollection languageCollection)
        {
            languageCollection.Add(language);
            string url = $"/languages/{language.Name}";
            return Results.Created(url, language);
        }

        public static IResult GetAllLanguages(LanguageCollection languageCollection)
        {
            return Results.Ok(languageCollection.getAll());
        }

        public static IResult GetLanguageByName(string name, LanguageCollection languageCollection)
        {
            Language lang = languageCollection.getAll().FirstOrDefault(l => l.Name == name);
            return lang != null ? Results.Ok(lang) : Results.NotFound();
        }

        public static IResult UpdateLanguage(string name, Language updatedLanguage, LanguageCollection languageCollection)
        {
            Language lang = languageCollection.getAll().FirstOrDefault(l => l.Name == name);
            if (lang == null)
            {
                return Results.NotFound();
            }
            lang.Name = updatedLanguage.Name;
            string url = "";
            return Results.Created(url, lang);
        }

        public static IResult DeleteLanguageByName(string name, LanguageCollection languageCollection)
        {
            Language lang = languageCollection.getAll().FirstOrDefault(l => l.Name == name);
            if (lang == null)
            {
                return Results.NotFound();
            }
            languageCollection.Delete(lang);
            return Results.Ok(lang);
        }

    }
}
