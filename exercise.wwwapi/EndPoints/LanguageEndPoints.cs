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

        public static IResult AddLanguage(Language language, ILanguageRepository languageRepository)
        {
            languageRepository.Add(language);
            string url = $"/languages/{language.Name}";
            return Results.Created(url, language);
        }

        public static IResult GetAllLanguages(ILanguageRepository languageRepository)
        {
            return Results.Ok(languageRepository.GetAll());
        }

        public static IResult GetLanguageByName(string name, ILanguageRepository languageRepository)
        {
            Language lang = languageRepository.GetAll().FirstOrDefault(l => l.Name == name);
            return lang != null ? Results.Ok(lang) : Results.NotFound();
        }

        public static IResult UpdateLanguage(string name, Language updatedLanguage, ILanguageRepository languageRepository)
        {
            Language lang = languageRepository.GetAll().FirstOrDefault(l => l.Name == name);
            if (lang == null)
            {
                return Results.NotFound();
            }
            lang.Name = updatedLanguage.Name;
            string url = "";
            return Results.Created(url, lang);
        }

        public static IResult DeleteLanguageByName(string name, ILanguageRepository languageRepository)
        {
            Language lang = languageRepository.GetAll().FirstOrDefault(l => l.Name == name);
            if (lang == null)
            {
                return Results.NotFound();
            }
            languageRepository.Delete(lang);
            return Results.Ok(lang);
        }

    }
}
